using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Infrastructure.Persistence.Configurations;

public class WeatherConfiguration : IEntityTypeConfiguration<Weather>
{
    public void Configure(EntityTypeBuilder<Weather> builder)
    {
        builder.ApplyDefaultTableName();

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Temperature).IsRequired();
        builder.Property(e => e.Pressure).IsRequired();
        builder.Property(e => e.Humidity).IsRequired();
        builder.Property(e => e.Lux).IsRequired();
        builder.Property(e => e.Timestamp).IsRequired();

        builder.HasIndex(e => e.Timestamp);
    }
}