#region

using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.CQRS.AddSensorsRead;
using WeatherForecast.CQRS.ExceptionHandling;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.RequestModels;

#endregion

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper<EspRequest, SensorsDTO> _sensorsMapper;

    public WeatherForecastController(IMapper<EspRequest, SensorsDTO> sensorsMapper, IMediator mediator)
    {
        _sensorsMapper = sensorsMapper;
        _mediator = mediator;
    }

    [HttpGet]
    public SensorsDTO Get()
    {
        return new SensorsDTO();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EspRequest request)
    {
        var dto = _sensorsMapper.Map(request);
        var result = await _mediator.Send(new AddSensorsReadCommand(dto))
                     ?? throw new ArgumentNullException();

        Console.WriteLine(request);
        Console.WriteLine(request.Temperature);
        Console.WriteLine(request.Pressure);
        Console.WriteLine(request.Humidity);
        Console.WriteLine(request.Lux);

        return result.Status switch
        {
            OperationStatus.Success => Ok(),
            OperationStatus.Failure => BadRequest(new { message = "Operation failed" }),
            OperationStatus.Exception => StatusCode(500, new { exception = result.ExceptionMessage }),
            _ => StatusCode(500)
        };
    }
}