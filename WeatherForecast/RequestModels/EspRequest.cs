namespace WeatherForecast.RequestModels;

public record EspRequest
{
    public required DateTimeOffset Time { get; init; }
    public double Temperature { get; init; }
    public double Pressure { get; init; }
    public double Humidity { get; init; }
    public double Lux { get; init; }
}