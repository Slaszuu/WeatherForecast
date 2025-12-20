#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.CQRS.ExceptionHandling;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence.Entities;

#endregion

namespace WeatherForecast.CQRS.AddSensorsRead;

public class AddSensorsReadCommandHandler(DbContext dbContext, IMapper<SensorsDTO, Sensors> mapper)
    : IRequestHandler<AddSensorsReadCommand, OperationResult<Unit>>
{
    public async Task<OperationResult<Unit>> Handle(AddSensorsReadCommand request, CancellationToken cancellationToken)
    {
        var sensors = mapper.Map(request.SensorsDTO);
        await dbContext.AddAsync(sensors, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new OperationResult<Unit>
        {
            Status = OperationStatus.Success
        };
    }
}