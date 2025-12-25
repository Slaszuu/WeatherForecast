using Microsoft.AspNetCore.SignalR;
using WeatherForecast.Shared.Constants;
using WeatherForecast.Shared.Contracts;
using WeatherForecast.Shared.DTOs;

namespace WeatherForecast.Infrastructure.SignalR;

public class SignalRWeatherNotifier(IHubContext<WeatherHub> hub) : IWeatherRealtimeNotifier
{
    public async Task WeatherUpdatedAsync(WeatherDTO weather, CancellationToken cancellationToken)
    {
        await hub.Clients.All.SendAsync(Consts.SignalRWeatherUpdatedMethod, weather, cancellationToken);
    }
}