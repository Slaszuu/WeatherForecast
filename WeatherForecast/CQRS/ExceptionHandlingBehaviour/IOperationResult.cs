namespace WeatherForecast.CQRS.ExceptionHandlingBehaviour;

public interface IOperationResult<T>
{
    T? Result { get; set; }
    OperationStatus Status { get; set; }
    string? ExceptionMessage { get; set; }
}