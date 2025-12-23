namespace WeatherForecast.Services.HttpResponseService;

public record HttpResponse<T>(int StatusCode, T? Result, string? ExceptionMessage);