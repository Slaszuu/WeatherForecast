using MediatR;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;

namespace WeatherForecast.CQRS.GetCurrentWeather;

public record GetCurrentWeatherQuery : IRequest<OperationResult<WeatherDTO>>;