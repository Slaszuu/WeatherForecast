#region

using MediatR;

#endregion

namespace WeatherForecast.CQRS.ExceptionHandlingBehaviour;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : IOperationResult<Unit>, new()
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