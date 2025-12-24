using MediatR;
using WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.Application.DTOs;

namespace WeatherForecast.Application.CQRS.Commands.AddSensorsRead;

public record AddSensorsReadCommand(SensorsDTO SensorsDTO) : IRequest<OperationResult<Unit>>;