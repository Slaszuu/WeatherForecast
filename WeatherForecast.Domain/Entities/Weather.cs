namespace WeatherForecast.Domain.Entities;

public class Weather
{
    private Weather()
    {
    }

    public Guid Id { get; init; }
    public DateTimeOffset Timestamp { get; init; }
    public double Temperature { get; init; }
    public double Pressure { get; init; }
    public double Humidity { get; init; }
    public double Lux { get; init; }

    public static Weather Create(Guid id, DateTimeOffset timestamp, double temperature, double humidity,
        double pressure,
        double lux)
    {
        return new Weather
        {
            Id = id,
            Timestamp = timestamp,
            Temperature = temperature,
            Humidity = humidity,
            Pressure = pressure,
            Lux = lux
        };
    }
}