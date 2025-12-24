using MediatR;
using WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.Application.DTOs;

namespace WeatherForecast.Application.CQRS.GetCurrentWeather;

public record GetCurrentWeatherQuery : IRequest<OperationResult<WeatherDTO>>;