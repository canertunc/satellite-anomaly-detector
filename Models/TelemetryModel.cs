
namespace AnomalyDetectionApp.Models
{
    public class TelemetryData
    {
        public string? Segment { get; set; }
        public string? Anomaly { get; set; }
        public string? Train { get; set; }
        public string? Channel { get; set; }
        public string? Sampling { get; set; }
        public string? Duration { get; set; }
        public string? Len { get; set; }
        public string? Mean { get; set; }
        public string? Var { get; set; }
        public string? Std { get; set; }
        public string? Kurtosis { get; set; }
        public string? Skew { get; set; }
        public string? N_Peaks { get; set; }
        public string? Smooth10_N_Peaks { get; set; }
        public string? Smooth20_N_Peaks { get; set; }
        public string? Diff_Peaks { get; set; }
        public string? Diff2_Peaks { get; set; }
        public string? Diff_Var { get; set; }
        public string? Diff2_Var { get; set; }
        public string? Gaps_Squared { get; set; }
        public string? Len_Weighted { get; set; }
        public string? Var_Div_Duration { get; set; }
        public string? Var_Div_Len { get; set; }
    }
}