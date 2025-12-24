using WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;

namespace WeatherForecast.API.Services.HttpResponseService;

public interface IHttpResponseService
{
    HttpResponse<T> GetHttpResponse<T>(OperationResult<T> operationResult);
}