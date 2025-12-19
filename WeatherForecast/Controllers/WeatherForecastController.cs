using Microsoft.AspNetCore.Mvc;
using WeatherForecast.DTOs;
using WeatherForecast.RequestModels;

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    [HttpGet]
    public SensorsDTO Get()
    {
        return new SensorsDTO();
    }

    [HttpPost]
    public IActionResult Post([FromBody] EspRequest request)
    {
        Console.WriteLine(request.Time);
        Console.WriteLine(request.Temperature);
        Console.WriteLine(request.Pressure);
        Console.WriteLine(request.Humidity);
        Console.WriteLine(request.Lux);
        
        return NoContent();
    }
}