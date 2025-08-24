
using AnomalyDetectionApp.Models;

namespace AnomalyDetectionApp.Helpers
{
    public static class TelemetryExtensions
    {
        public static TelemetryTraining ToTraining(this TelemetryLabeled labeled)
        {
            return new TelemetryTraining
            {
                Segment = labeled.Segment,
                Anomaly = labeled.Anomaly,
                Timestamp = labeled.Timestamp,
                Duration = labeled.Duration,
                Len = labeled.Len,
                Mean = labeled.Mean,
                Var = labeled.Var,
                Std = labeled.Std,
                Kurtosis = labeled.Kurtosis,
                Skew = labeled.Skew,
                N_Peaks = labeled.N_Peaks,
                Smooth10_N_Peaks = labeled.Smooth10_N_Peaks,
                Smooth20_N_Peaks = labeled.Smooth20_N_Peaks,
                Diff_Peaks = labeled.Diff_Peaks,
                Diff2_Peaks = labeled.Diff2_Peaks,
                Diff_Var = labeled.Diff_Var,
                Diff2_Var = labeled.Diff2_Var,
                Gaps_Squared = labeled.Gaps_Squared,
                Len_Weighted = labeled.Len_Weighted,
                Var_Div_Duration = labeled.Var_Div_Duration,
                Var_Div_Len = labeled.Var_Div_Len
            };
        }
    }
}
