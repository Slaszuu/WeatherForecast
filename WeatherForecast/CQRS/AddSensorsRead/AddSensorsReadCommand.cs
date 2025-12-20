#region

using MediatR;
using WeatherForecast.DTOs;

#endregion

namespace WeatherForecast.CQRS.AddSensorsRead;

public record AddSensorsReadCommand(SensorsDTO SensorsDTO) : IRequest<bool>;