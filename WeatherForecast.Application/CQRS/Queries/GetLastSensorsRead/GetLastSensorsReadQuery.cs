using MediatR;
using WeatherForecast.Application.DTOs;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.Application.CQRS.Queries.GetLastSensorsRead;

public record GetLastSensorsReadQuery : IRequest<OperationResult<SensorsDTO>>;