using Microsoft.EntityFrameworkCore;
using AnomalyDetectionApp.Models;

namespace AnomalyDetectionApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TelemetryRaw> TelemetryRaws { get; set; } = null!;
        public DbSet<TelemetryLabeled> TelemetyLabeleds { get; set; }  = null!;
        public DbSet<TelemetryTraining> TelemetyTrainings { get; set; }  = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelemetryRaw>()
                .HasKey(t => t.Segment);

            modelBuilder.Entity<TelemetryLabeled>()
                .HasKey(t => t.Segment);

            modelBuilder.Entity<TelemetryTraining>()
                .HasKey(t => t.Segment);

            base.OnModelCreating(modelBuilder);
        }
    }
}