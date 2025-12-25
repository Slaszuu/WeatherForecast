using MediatR;
using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Events;
using WeatherForecast.Domain.Services.MeasurementsCalibrationService;
using WeatherForecast.Infrastructure.Persistence;
using WeatherForecast.Shared.Contracts;
using WeatherForecast.Shared.DTOs;

namespace WeatherForecast.Application.DomainEventHandlers.SensorsReadAddedDomainEventHandler;

public class SensorsReadAddedDomainEventHandler(
    IMeasurementsCalibrationService calibrationService,
    AppDbContext dbContext,
    IWeatherRealtimeNotifier weatherRealtimeNotifier,
    IMapper<Weather, WeatherDTO> mapper)
    : INotificationHandler<SensorsReadAddedDomainEvent>
{
    public async Task Handle(SensorsReadAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        var weather = calibrationService.Calibrate(notification.Sensors);
        var dto = mapper.Map(weather);

        await dbContext.AddAsync(weather, cancellationToken);
        await weatherRealtimeNotifier.WeatherUpdatedAsync(dto, cancellationToken);
    }
}