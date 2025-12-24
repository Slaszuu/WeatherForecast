using System.Net;
using WeatherForecast.Shared.Enums;
using WeatherForecast.Shared.OperationResult;

namespace WeatherForecast.API.Services.HttpResponseService;

public class HttpResponseService : IHttpResponseService
{
    public HttpResponse<T> GetHttpResponse<T>(OperationResult<T> operationResult)
    {
        return operationResult.Status switch
        {
            OperationStatus.Success =>
                new HttpResponse<T>(
                    StatusCode: (int)HttpStatusCode.OK,
                    Result: operationResult.Result,
                    ExceptionMessage: null),
            OperationStatus.Failure =>
                new HttpResponse<T>(
                    StatusCode: (int)HttpStatusCode.NotFound,
                    Result: default,
                    ExceptionMessage: operationResult.ExceptionMessage),
            _ =>
                new HttpResponse<T>(
                    StatusCode: (int)HttpStatusCode.InternalServerError,
                    Result: default,
                    ExceptionMessage: operationResult.ExceptionMessage)
        };
    }
}