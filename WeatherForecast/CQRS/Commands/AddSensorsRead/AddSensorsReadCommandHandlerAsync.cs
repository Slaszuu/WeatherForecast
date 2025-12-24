using MediatR;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence;
using WeatherForecast.Persistence.Entities;
using WeatherForecast.Services.MeasurementsCalibrationService;

namespace WeatherForecast.CQRS.Commands.AddSensorsRead;

public class AddSensorsReadCommandHandlerAsync(
    AppDbContext dbContext,
    IMapper<SensorsDTO, Sensors> mapper,
    IMeasurementsCalibrationService measurementsCalibrationService)
    : IRequestHandler<AddSensorsReadCommand, OperationResult<Unit>>
{
    public async Task<OperationResult<Unit>> Handle(AddSensorsReadCommand request, CancellationToken cancellationToken)
    {
        var sensors = mapper.Map(request.SensorsDTO);

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        await dbContext.AddAsync(sensors, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var realWeather = measurementsCalibrationService.Calibrate(sensors);

        await dbContext.AddAsync(realWeather, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);

        return OperationResult<Unit>.Success(default);
    }
}