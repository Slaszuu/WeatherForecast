#region

using WeatherForecast.CQRS.ExceptionHandlingBehaviour;

#endregion

namespace WeatherForecast.Services.HttpResponseService;

public interface IHttpResponseService
{
    HttpResponse<T> GetHttpResponse<T>(OperationResult<T> operationResult);
}