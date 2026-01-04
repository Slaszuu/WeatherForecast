using Microsoft.AspNetCore.SignalR;

namespace WeatherForecast.Infrastructure.SignalR;

public class WeatherHub : Hub
{
    public const string HubUrl = "/api/hubs/weather";

    public async Task JoinStation(Guid stationId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, stationId.ToString());
    }

    public async Task LeaveStation(Guid stationId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, stationId.ToString());
    }
}