#region

using MediatR;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence;
using WeatherForecast.Persistence.Entities;

#endregion

namespace WeatherForecast.CQRS.Commands.AddSensorsRead;

public class AddSensorsReadCommandHandlerAsync(AppDbContext dbContext, IMapper<SensorsDTO, Sensors> mapper)
    : IRequestHandler<AddSensorsReadCommand, OperationResult<Unit>>
{
    public async Task<OperationResult<Unit>> Handle(AddSensorsReadCommand request, CancellationToken cancellationToken)
    {
        var sensors = mapper.Map(request.SensorsDTO);
        await dbContext.AddAsync(sensors, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return OperationResult<Unit>.Success(default);
    }
}