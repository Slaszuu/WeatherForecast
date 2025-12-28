using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Infrastructure.Persistence;
using WeatherForecast.Shared.DTOs;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.Application.CQRS.GetCurrentWeather;

public class GetCurrentWeatherHandlerAsync(AppDbContext dbContext, IMapper<Weather, WeatherDTO> mapper)
    : IRequestHandler<GetCurrentWeatherQuery, OperationResult<WeatherDTO>>
{
    public async Task<OperationResult<WeatherDTO>> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Weather
            .AsNoTracking()
            .OrderByDescending(e => e.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            return OperationResult<WeatherDTO>.Failure("Weather data not found.");
        }

        var dto = mapper.Map(entity);

        return OperationResult<WeatherDTO>.Success(dto);
    }
}