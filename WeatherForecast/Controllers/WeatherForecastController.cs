using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.RequestModels;

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMapper<EspRequest, SensorsDTO> _sensorsMapper;
    private readonly IMediator _mediator;

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
    public IActionResult Post([FromBody] EspRequest request)
    {
        var dto = _sensorsMapper.Map(request);
        _mediator.Send(dto);
        
        Console.WriteLine(request.Time);
        Console.WriteLine(request.Temperature);
        Console.WriteLine(request.Pressure);
        Console.WriteLine(request.Humidity);
        Console.WriteLine(request.Lux);
        
        return NoContent();
    }
}