using MediatR;
using WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.Application.DTOs;

namespace WeatherForecast.Application.CQRS.Queries.GetLastSensorsRead;

public record GetLastSensorsReadQuery : IRequest<OperationResult<SensorsDTO>>;