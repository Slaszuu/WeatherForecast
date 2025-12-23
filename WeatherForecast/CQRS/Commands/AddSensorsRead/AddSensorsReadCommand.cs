using MediatR;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.DTOs;

namespace WeatherForecast.CQRS.Commands.AddSensorsRead;

public record AddSensorsReadCommand(SensorsDTO SensorsDTO) : IRequest<OperationResult<Unit>>;