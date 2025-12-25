using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.API.RequestModels;
using WeatherForecast.API.Services.HttpResponseService;
using WeatherForecast.Application.CQRS.Commands.AddSensorsRead;
using WeatherForecast.Application.CQRS.GetCurrentWeather;
using WeatherForecast.Application.CQRS.Queries.GetLastSensorsRead;
using WeatherForecast.Shared.DTOs;

namespace WeatherForecast.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    IMediator mediator,
    IHttpResponseService httpResponseService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetLastSensorsReadQuery();
        var result = await mediator.Send(query);
        var httpResponse = httpResponseService.GetHttpResponse(result);
        return StatusCode(httpResponse.StatusCode, httpResponse);
    }

    [HttpGet("current-weather")]
    public async Task<IActionResult> GetCurrentWeather()
    {
        var query = new GetCurrentWeatherQuery();
        var result = await mediator.Send(query);
        var httpResponse = httpResponseService.GetHttpResponse(result);
        return StatusCode(httpResponse.StatusCode, httpResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EspRequest request)
    {
        var dto = new SensorsDTO
        {
            Timestamp = request.Time,
            CpuTemperature = request.CpuTemperature,
            Temperature = request.Temperature,
            Pressure = request.Pressure,
            Humidity = request.Humidity,
            Lux = request.Lux
        };

        var result = await mediator.Send(new AddSensorsReadCommand(dto));

        var httpResponse = httpResponseService.GetHttpResponse(result);
        return StatusCode(httpResponse.StatusCode, httpResponse);
    }
}