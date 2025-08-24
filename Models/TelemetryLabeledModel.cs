using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnomalyDetectionApp.Models
{
    public class TelemetryLabeled
    {
        [Key]
        [Column("segment")]
        public  long  Segment { get; set; }

        [Column("anomaly")]
        public  float Anomaly { get; set; }

        [Column("timestamp")]
        public  DateTime Timestamp { get; set; }

        [Column("duration")]
        public  float Duration { get; set; }

        [Column("len")]
        public  float Len { get; set; }

        [Column("mean")]
        public  float Mean { get; set; }

        [Column("var")]
        public  float Var { get; set; }

        [Column("std")]
        public  float Std { get; set; }

        [Column("kurtosis")]
        public  float Kurtosis { get; set; }

        [Column("skew")]
        public  float Skew { get; set; }

        [Column("n_peaks")]
        public  float N_Peaks { get; set; }

        [Column("smooth10_n_peaks")]
        public  float Smooth10_N_Peaks { get; set; }

        [Column("smooth20_n_peaks")]
        public  float Smooth20_N_Peaks { get; set; }

        [Column("diff_peaks")]
        public  float Diff_Peaks { get; set; }

        [Column("diff2_peaks")]
        public  float Diff2_Peaks { get; set; }

        [Column("diff_var")]
        public  float Diff_Var { get; set; }

        [Column("diff2_var")]
        public  float Diff2_Var { get; set; }

        [Column("gaps_squared")]
        public  float Gaps_Squared { get; set; }

        [Column("len_weighted")]
        public  float Len_Weighted { get; set; }

        [Column("var_div_duration")]
        public  float Var_Div_Duration { get; set; }

        [Column("var_div_len")]
        public  float Var_Div_Len { get; set; }
    }
}