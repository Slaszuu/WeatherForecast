using WeatherForecast.Application.DTOs;
using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Application.Mappers;

public class WeatherMapper :
    IMapper<WeatherDTO, Weather>,
    IMapper<Weather, WeatherDTO>
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

    public Weather Map(WeatherDTO source)
    {
        return new Weather
        {
            Timestamp = source.Timestamp,
            Temperature = source.Temperature,
            Pressure = source.Pressure,
            Humidity = source.Humidity,
            Lux = source.Lux,
        };
    }
}