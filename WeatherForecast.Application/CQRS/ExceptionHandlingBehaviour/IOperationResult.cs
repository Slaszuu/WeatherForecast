namespace WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;

public interface IOperationResult
{
    OperationStatus Status { get; set; }
    string? ExceptionMessage { get; set; }
}

public interface IOperationResult<T> : IOperationResult
{
    T? Result { get; set; }
}