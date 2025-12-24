using Microsoft.EntityFrameworkCore;
using WeatherForecast.Infrastructure.Persistence;

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

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }

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