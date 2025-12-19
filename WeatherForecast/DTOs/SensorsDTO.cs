namespace WeatherForecast.DTOs;

public record SensorsDTO
{
    public DateTimeOffset Timestamp { get; init; }
    public double Temperature { get; init; }
    public double Pressure { get; init; }
    public double Humidity { get; init; }
    public double Lux { get; init; }
}