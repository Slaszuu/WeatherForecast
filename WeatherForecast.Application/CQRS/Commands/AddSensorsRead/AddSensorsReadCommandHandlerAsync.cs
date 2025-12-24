using MediatR;
using WeatherForecast.Application.DomainEventsDispatcher;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Infrastructure.Persistence;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.Application.CQRS.Commands.AddSensorsRead;

public class AddSensorsReadCommandHandlerAsync(AppDbContext dbContext, IDomainEventsDispatcher domainEventsDispatcher)
    : IRequestHandler<AddSensorsReadCommand, OperationResult<Unit>>
{
    public async Task<OperationResult<Unit>> Handle(AddSensorsReadCommand request, CancellationToken cancellationToken)
    {
        var sensors = Sensors.Create(
            timestamp: request.SensorsDTO.Timestamp,
            cpuTemperature: request.SensorsDTO.CpuTemperature,
            temperature: request.SensorsDTO.Temperature,
            pressure: request.SensorsDTO.Pressure,
            humidity: request.SensorsDTO.Humidity,
            lux: request.SensorsDTO.Lux);

        await dbContext.AddAsync(sensors, cancellationToken);

        await domainEventsDispatcher.DispatchAsync(sensors.DomainEvents, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return OperationResult<Unit>.Success(default);
    }
}