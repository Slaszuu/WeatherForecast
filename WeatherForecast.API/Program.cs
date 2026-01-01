using Microsoft.EntityFrameworkCore;
using WeatherForecast.API.Extensions;
using WeatherForecast.Infrastructure.Persistence;
using WeatherForecast.Infrastructure.SignalR;

namespace WeatherForecast.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connString, npgqsqlOptions =>
        {
            npgqsqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        }));

        builder.Services.AddApplicationServices();

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        var app = builder.Build();

        app.UseRouting();

        app.UseCors();

        app.MapHub<WeatherHub>(WeatherHub.HubUrl);

        if (app.Environment.IsDevelopment())
        {
            // Configure the HTTP request pipeline.
            app.MapOpenApi();
            app.ApplyMigrations();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}