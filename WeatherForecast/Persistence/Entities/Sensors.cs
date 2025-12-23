using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Persistence.Entities;

public class Sensors
{
    [Key] public int Id { get; set; }

    public DateTimeOffset Timestamp { get; set; }

    public double CpuTemperature { get; set; }

    public double Temperature { get; set; }

    public double Pressure { get; set; }

    public double Humidity { get; set; }

    public double Lux { get; set; }
}