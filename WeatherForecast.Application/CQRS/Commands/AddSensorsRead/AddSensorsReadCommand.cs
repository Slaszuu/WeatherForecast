using MediatR;
using WeatherForecast.Shared.DTOs;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.Application.CQRS.Commands.AddSensorsRead;

public record AddSensorsReadCommand(SensorsDTO SensorsDTO) : IRequest<OperationResult<Unit>>;