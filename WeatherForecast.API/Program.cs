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
        var origins = builder.Configuration.GetValue<string>("CORS_ORIGINS")!;
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(origins)
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
        }

        //TODO: Move the migrations to separated docker compose or github actions
        var runMigrationEnvAsString = builder.Configuration.GetValue<string>("RUN_MIGRATION");
        bool.TryParse(runMigrationEnvAsString, out var runMigration);
        if (runMigration || app.Environment.IsDevelopment())
        {
            app.ApplyMigrations();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}