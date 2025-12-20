namespace WeatherForecast.CQRS.ExceptionHandling;

public class OperationResult<T> : IOperationResult
{
    public OperationStatus Status { get; set; }
    public string? ExceptionMessage { get; set; }
}