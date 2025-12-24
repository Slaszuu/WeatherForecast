using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Entities;

public class Weather
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; init; }

    public DateTimeOffset Timestamp { get; init; }

    public double Temperature { get; init; }

    public double Pressure { get; init; }

    public double Humidity { get; init; }

    public double Lux { get; init; }
}