using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Shared.DTOs;

namespace WeatherForecast.Application.Mappers;

public class SensorsMapper : IMapper<Sensors, SensorsDTO>
{
    public SensorsDTO Map(Sensors source)
    {
        return new SensorsDTO
        {
            Timestamp = source.Timestamp,
            CpuTemperature = source.CpuTemperature,
            Temperature = source.Temperature,
            Pressure = source.Pressure,
            Humidity = source.Humidity,
            Lux = source.Lux,
        };
    }
}