using Microsoft.AspNetCore.SignalR;
using AnomalyDetectionApp.Data;
using AnomalyDetectionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AnomalyDetectionApp.Hubs
{
    public class TelemetryHub : Hub
    {
        private readonly AppDbContext _db;

        public TelemetryHub(AppDbContext db)
        {
            _db = db;
        }

        private bool isRunning = false;

        public async Task StartDetection()
        {
            if (isRunning) return; 
            isRunning = true;

            while (isRunning)
            {
                var newData = await _db.TelemetryRaws.ToListAsync();

                foreach (var item in newData)
                {
                    var telemetryLabeled = new TelemetryLabeled();
                    var featureValues = new Dictionary<string, double?>(); 
                    var currentFeatures = featureValues.ToDictionary(k => k.Key, k => (double?)null);

                    foreach (var prop in typeof(TelemetryLabeled).GetProperties())
                    {
                        if (prop.Name == "Segment" || prop.Name == "Anomaly" || prop.Name == "Timestamp") continue;
                        var value = item.GetType().GetProperty(prop.Name)?.GetValue(item);
                        if (value != null) currentFeatures[prop.Name] = Convert.ToDouble(value);
                        prop.SetValue(telemetryLabeled, value);
                    }

                    var input = new { values = currentFeatures.Values.Select(v => v ?? 0.0).ToList() };

                    using var http = new HttpClient();
                    var response = await http.PostAsJsonAsync("http://9.223.178.203:5001/predict", input);
                    var result = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();

                    if (result != null)
                    {
                        telemetryLabeled.Anomaly = result["prediction"];
                        var lastSegment = (await _db.TelemetyLabeleds.OrderByDescending(t => t.Segment).FirstOrDefaultAsync())?.Segment ?? 0;
                        telemetryLabeled.Timestamp = DateTime.UtcNow;
                        telemetryLabeled.Segment = long.Parse(telemetryLabeled.Timestamp.ToString("yyyyMMddHHmmssfff"));
                    }

                    await _db.TelemetyLabeleds.AddAsync(telemetryLabeled);
                    _db.TelemetryRaws.Remove(item);
                    await _db.SaveChangesAsync();

                    await Clients.All.SendAsync("ReceiveTelemetry", telemetryLabeled);
                }

                await Task.Delay(500); 
            }
        }

        public Task StopDetection()
        {
            isRunning = false;
            return Task.CompletedTask;
        }
    }
}