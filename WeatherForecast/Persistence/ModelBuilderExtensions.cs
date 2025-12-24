using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherForecast.Persistence;

public static class ModelBuilderExtensions
{
    public static void ApplyDefaultTableName<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.ToTable(typeof(T).Name.ToLowerInvariant());
    }
}