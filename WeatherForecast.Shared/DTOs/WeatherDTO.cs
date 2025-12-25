namespace WeatherForecast.Shared.DTOs;

public record WeatherDTO
{
    public DateTimeOffset Timestamp { get; init; }
    public double Temperature { get; init; }
    public double Pressure { get; init; }
    public double Humidity { get; init; }
    public double Lux { get; init; }
}