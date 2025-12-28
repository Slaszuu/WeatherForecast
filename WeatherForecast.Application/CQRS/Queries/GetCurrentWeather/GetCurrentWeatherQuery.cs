using MediatR;
using WeatherForecast.Shared.DTOs;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.Application.CQRS.GetCurrentWeather;

public record GetCurrentWeatherQuery : IRequest<OperationResult<WeatherDTO>>;