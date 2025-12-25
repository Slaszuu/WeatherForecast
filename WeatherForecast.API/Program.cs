using Microsoft.EntityFrameworkCore;
using WeatherForecast.Infrastructure.Persistence;
using WeatherForecast.Infrastructure.SignalR;

namespace WeatherForecast.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"[DEBUG] Connection String: {connString}");
        Console.WriteLine("--------------------------------------------------");

        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connString));

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

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }

        app.MapHub<WeatherHub>(WeatherHub.HubUrl);

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