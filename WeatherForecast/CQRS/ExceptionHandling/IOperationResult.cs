namespace WeatherForecast.CQRS.ExceptionHandling;

public interface IOperationResult
{
    OperationStatus Status { get; set; }
    string? ExceptionMessage { get; set; }
}