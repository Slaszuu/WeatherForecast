using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.CQRS.Commands.AddSensorsRead;
using WeatherForecast.CQRS.GetCurrentWeather;
using WeatherForecast.CQRS.Queries.GetLastSensorsRead;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.RequestModels;
using WeatherForecast.Services.HttpResponseService;

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    IMapper<EspRequest, SensorsDTO> sensorsMapper,
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
        var dto = sensorsMapper.Map(request);
        var result = await mediator.Send(new AddSensorsReadCommand(dto));

        var httpResponse = httpResponseService.GetHttpResponse(result);
        return StatusCode(httpResponse.StatusCode, httpResponse);
    }
}