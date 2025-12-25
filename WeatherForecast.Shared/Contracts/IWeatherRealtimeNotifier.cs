using WeatherForecast.Shared.DTOs;

namespace WeatherForecast.Shared.Contracts;

public interface IWeatherRealtimeNotifier
{
    Task WeatherUpdatedAsync(WeatherDTO weather, CancellationToken cancellationToken);
}