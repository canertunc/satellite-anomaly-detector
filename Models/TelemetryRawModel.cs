
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnomalyDetectionApp.Models
{
    public class TelemetryRaw
    {
        
        [Column("segment")]
        public required long Segment { get; set; }

        [Column("timestamp")]
        public required DateTime Timestamp { get; set; } 
        [Column("duration")]
        public required float Duration { get; set; }

        [Column("len")]
        public required float Len { get; set; }

        [Column("mean")]
        public required float Mean { get; set; }

        [Column("var")]
        public required float Var { get; set; }

        [Column("std")]
        public required float Std { get; set; }

        [Column("kurtosis")]
        public required float Kurtosis { get; set; }

        [Column("skew")]
        public required float Skew { get; set; }

        [Column("n_peaks")]
        public required float N_Peaks { get; set; }

        [Column("smooth10_n_peaks")]
        public required float Smooth10_N_Peaks { get; set; }

        [Column("smooth20_n_peaks")]
        public required float Smooth20_N_Peaks { get; set; }

        [Column("diff_peaks")]
        public required float Diff_Peaks { get; set; }

        [Column("diff2_peaks")]
        public required float Diff2_Peaks { get; set; }

        [Column("diff_var")]
        public required float Diff_Var { get; set; }

        [Column("diff2_var")]
        public required float Diff2_Var { get; set; }

        [Column("gaps_squared")]
        public required float Gaps_Squared { get; set; }

        [Column("len_weighted")]
        public required float Len_Weighted { get; set; }

        [Column("var_div_duration")]
        public required float Var_Div_Duration { get; set; }

        [Column("var_div_len")]
        public required float Var_Div_Len { get; set; }
    }
}