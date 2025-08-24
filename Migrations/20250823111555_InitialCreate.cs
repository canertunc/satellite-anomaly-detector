using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnomalyDetectionApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelemetryRaws",
                columns: table => new
                {
                    segment = table.Column<float>(type: "real", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    duration = table.Column<float>(type: "real", nullable: false),
                    len = table.Column<float>(type: "real", nullable: false),
                    mean = table.Column<float>(type: "real", nullable: false),
                    var = table.Column<float>(type: "real", nullable: false),
                    std = table.Column<float>(type: "real", nullable: false),
                    kurtosis = table.Column<float>(type: "real", nullable: false),
                    skew = table.Column<float>(type: "real", nullable: false),
                    n_peaks = table.Column<float>(type: "real", nullable: false),
                    smooth10_n_peaks = table.Column<float>(type: "real", nullable: false),
                    smooth20_n_peaks = table.Column<float>(type: "real", nullable: false),
                    diff_peaks = table.Column<float>(type: "real", nullable: false),
                    diff2_peaks = table.Column<float>(type: "real", nullable: false),
                    diff_var = table.Column<float>(type: "real", nullable: false),
                    diff2_var = table.Column<float>(type: "real", nullable: false),
                    gaps_squared = table.Column<float>(type: "real", nullable: false),
                    len_weighted = table.Column<float>(type: "real", nullable: false),
                    var_div_duration = table.Column<float>(type: "real", nullable: false),
                    var_div_len = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetryRaws", x => x.segment);
                });

            migrationBuilder.CreateTable(
                name: "TelemetyLabeleds",
                columns: table => new
                {
                    segment = table.Column<float>(type: "real", nullable: false),
                    anomaly = table.Column<float>(type: "real", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    duration = table.Column<float>(type: "real", nullable: false),
                    len = table.Column<float>(type: "real", nullable: false),
                    mean = table.Column<float>(type: "real", nullable: false),
                    var = table.Column<float>(type: "real", nullable: false),
                    std = table.Column<float>(type: "real", nullable: false),
                    kurtosis = table.Column<float>(type: "real", nullable: false),
                    skew = table.Column<float>(type: "real", nullable: false),
                    n_peaks = table.Column<float>(type: "real", nullable: false),
                    smooth10_n_peaks = table.Column<float>(type: "real", nullable: false),
                    smooth20_n_peaks = table.Column<float>(type: "real", nullable: false),
                    diff_peaks = table.Column<float>(type: "real", nullable: false),
                    diff2_peaks = table.Column<float>(type: "real", nullable: false),
                    diff_var = table.Column<float>(type: "real", nullable: false),
                    diff2_var = table.Column<float>(type: "real", nullable: false),
                    gaps_squared = table.Column<float>(type: "real", nullable: false),
                    len_weighted = table.Column<float>(type: "real", nullable: false),
                    var_div_duration = table.Column<float>(type: "real", nullable: false),
                    var_div_len = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetyLabeleds", x => x.segment);
                });

            migrationBuilder.CreateTable(
                name: "TelemetyTrainings",
                columns: table => new
                {
                    segment = table.Column<float>(type: "real", nullable: false),
                    anomaly = table.Column<float>(type: "real", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    duration = table.Column<float>(type: "real", nullable: false),
                    len = table.Column<float>(type: "real", nullable: false),
                    mean = table.Column<float>(type: "real", nullable: false),
                    var = table.Column<float>(type: "real", nullable: false),
                    std = table.Column<float>(type: "real", nullable: false),
                    kurtosis = table.Column<float>(type: "real", nullable: false),
                    skew = table.Column<float>(type: "real", nullable: false),
                    n_peaks = table.Column<float>(type: "real", nullable: false),
                    smooth10_n_peaks = table.Column<float>(type: "real", nullable: false),
                    smooth20_n_peaks = table.Column<float>(type: "real", nullable: false),
                    diff_peaks = table.Column<float>(type: "real", nullable: false),
                    diff2_peaks = table.Column<float>(type: "real", nullable: false),
                    diff_var = table.Column<float>(type: "real", nullable: false),
                    diff2_var = table.Column<float>(type: "real", nullable: false),
                    gaps_squared = table.Column<float>(type: "real", nullable: false),
                    len_weighted = table.Column<float>(type: "real", nullable: false),
                    var_div_duration = table.Column<float>(type: "real", nullable: false),
                    var_div_len = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetyTrainings", x => x.segment);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelemetryRaws");

            migrationBuilder.DropTable(
                name: "TelemetyLabeleds");

            migrationBuilder.DropTable(
                name: "TelemetyTrainings");
        }
    }
}
