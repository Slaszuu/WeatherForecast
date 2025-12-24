using MediatR;

namespace WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : IOperationResult, new()
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
            var result = new TResponse
            {
                Status = OperationStatus.Exception,
                ExceptionMessage = ex.Message
            };
            return result;
        }
    }
}