using MediatR;
using WeatherForecast.API.Services.HttpResponseService;
using WeatherForecast.Application.CQRS.Commands.AddSensorsRead;
using WeatherForecast.Application.CQRS.ExceptionHandlingBehaviour;
using WeatherForecast.Application.DomainEventsDispatcher;
using WeatherForecast.Application.Mappers;
using WeatherForecast.Domain.Services.MeasurementsCalibrationService;

namespace WeatherForecast.API;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<AddSensorsReadCommandHandlerAsync>());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        // Mappers
        services.Scan(scan => scan
            .FromAssemblies(typeof(SensorsMapper).Assembly)
            .AddClasses(c => c.Where(t => t.Name.EndsWith("Mapper")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        //Transient
        services.AddTransient<IHttpResponseService, HttpResponseService>();
        services.AddTransient<IMeasurementsCalibrationService, MeasurementsCalibrationService>();

        //Scoped
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
    }
}