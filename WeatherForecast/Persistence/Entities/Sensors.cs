using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Persistence.Entities;

public class Sensors
{
    [Key] public int Id { get; init; }

    public DateTimeOffset Timestamp { get; init; }

    public double CpuTemperature { get; init; }

    public double Temperature { get; init; }

    public double Pressure { get; init; }

    public double Humidity { get; init; }

    public double Lux { get; init; }
}