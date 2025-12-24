using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Application.DTOs;
using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Infrastructure.Persistence;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.Application.CQRS.Queries.GetLastSensorsRead;

public class GetLastSensorsReadQueryHandlerAsync(AppDbContext dbContext, IMapper<Sensors, SensorsDTO> mapper)
    : IRequestHandler<GetLastSensorsReadQuery, OperationResult<SensorsDTO>>
{
    public async Task<OperationResult<SensorsDTO>> Handle(GetLastSensorsReadQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Sensors
            .AsNoTracking()
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