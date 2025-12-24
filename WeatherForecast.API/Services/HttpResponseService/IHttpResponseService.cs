using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.API.Services.HttpResponseService;

public interface IHttpResponseService
{
    HttpResponse<T> GetHttpResponse<T>(OperationResult<T> operationResult);
}