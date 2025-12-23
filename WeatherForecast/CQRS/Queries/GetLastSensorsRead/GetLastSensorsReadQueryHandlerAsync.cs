#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence;
using WeatherForecast.Persistence.Entities;

#endregion

namespace WeatherForecast.CQRS.Queries.GetLastSensorsRead;

public class GetLastSensorsReadQueryHandlerAsync(AppDbContext dbContext, IMapper<Sensors, SensorsDTO> mapper)
    : IRequestHandler<GetLastSensorsReadQuery, OperationResult<SensorsDTO>>
{
    public async Task<OperationResult<SensorsDTO>> Handle(GetLastSensorsReadQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Sensors
            .OrderByDescending(e => e.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            return OperationResult<SensorsDTO>.Failure("Sensors data not found.");
        }

        var dto = mapper.Map(entity);

        return OperationResult<SensorsDTO>.Success(dto);
    }
}