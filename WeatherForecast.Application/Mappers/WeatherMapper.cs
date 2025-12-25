using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Shared.DTOs;

namespace WeatherForecast.Application.Mappers;

public class WeatherMapper : IMapper<Weather, WeatherDTO>
{
    public WeatherDTO Map(Weather source)
    {
        return new WeatherDTO
        {
            Timestamp = source.Timestamp,
            Temperature = source.Temperature,
            Pressure = source.Pressure,
            Humidity = source.Humidity,
            Lux = source.Lux,
        };
    }
}