using MediatR;
using WeatherForecast.Domain.Events;
using WeatherForecast.Domain.Services.MeasurementsCalibrationService;
using WeatherForecast.Infrastructure.Persistence;

namespace WeatherForecast.Application.DomainEventHandlers.SensorsReadAddedDomainEventHandler;

public class SensorsReadAddedDomainEventHandler(IMeasurementsCalibrationService calibrationService, AppDbContext dbContext)
    : INotificationHandler<SensorsReadAddedDomainEvent>
{
    public async Task Handle(SensorsReadAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        var weather = calibrationService.Calibrate(notification.Sensors);

        await dbContext.AddAsync(weather, cancellationToken);
    }
}