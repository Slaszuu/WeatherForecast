#region

using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.CQRS.ExceptionHandling;

#endregion

namespace WeatherForecast;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");

        //TODO: remove this after making sure the connection string is resolved correctly 
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"[DEBUG] Connection String: {connString}");
        Console.WriteLine("--------------------------------------------------");

        // Add services to the container.
        builder.Services.AddDbContext<DbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.Scan(scan => scan
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.Where(t => t.Name.EndsWith("Mapper")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        //MediatR
        builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}