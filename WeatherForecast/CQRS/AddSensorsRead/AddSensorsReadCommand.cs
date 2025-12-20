#region

using MediatR;
using WeatherForecast.CQRS.ExceptionHandling;
using WeatherForecast.DTOs;

#endregion

namespace WeatherForecast.CQRS.AddSensorsRead;

public record AddSensorsReadCommand(SensorsDTO SensorsDTO) : IRequest<OperationResult<Unit>>;