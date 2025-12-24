namespace WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;

public class OperationResult<T> : IOperationResult<T>
{
    public T? Result { get; set; }
    public OperationStatus Status { get; set; }
    public string? ExceptionMessage { get; set; }

    public static OperationResult<T> Success(T result) =>
        new() { Result = result, Status = OperationStatus.Success };

    public static OperationResult<T> Failure(string? message = null) =>
        new() { Status = OperationStatus.Failure, ExceptionMessage = message };
}