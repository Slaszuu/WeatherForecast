using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence;
using WeatherForecast.Persistence.Entities;

namespace WeatherForecast.CQRS.GetCurrentWeather;

public class GetCurrentWeatherHandlerAsync(AppDbContext dbContext, IMapper<Weather, WeatherDTO> mapper)
    : IRequestHandler<GetCurrentWeatherQuery, OperationResult<WeatherDTO>>
{
    public async Task<OperationResult<WeatherDTO>> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Weather
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