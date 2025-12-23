using MediatR;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;

namespace WeatherForecast.CQRS.Queries.GetLastSensorsRead;

public record GetLastSensorsReadQuery : IRequest<OperationResult<SensorsDTO>>;