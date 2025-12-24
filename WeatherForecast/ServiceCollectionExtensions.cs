using System.Reflection;
using MediatR;
using WeatherForecast.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.Services.HttpResponseService;
using WeatherForecast.Services.MeasurementsCalibrationService;

namespace WeatherForecast;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        // Mappers
        services.Scan(scan => scan
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.Where(t => t.Name.EndsWith("Mapper")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddTransient<IHttpResponseService, HttpResponseService>();
        services.AddTransient<IMeasurementsCalibrationService, MeasurementsCalibrationService>();
    }
}