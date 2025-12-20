using WeatherForecast.Persistence.Entities;

namespace WeatherForecast.Persistence;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Sensors> Sensors { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sensors>(entity =>
        {
            entity.ToTable("sensors");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Temperature)
                .IsRequired();

            entity.Property(e => e.Pressure)
                .IsRequired();

            entity.Property(e => e.Humidity)
                .IsRequired();

            entity.Property(e => e.Lux)
                .IsRequired();

            entity.Property(e => e.Timestamp)
                .IsRequired();

            entity.HasIndex(e => e.Timestamp);
        });
    }
}
