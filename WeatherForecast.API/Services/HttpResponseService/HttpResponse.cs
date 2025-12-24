namespace WeatherForecast.API.Services.HttpResponseService;

public record HttpResponse<T>(int StatusCode, T? Result, string? ExceptionMessage);