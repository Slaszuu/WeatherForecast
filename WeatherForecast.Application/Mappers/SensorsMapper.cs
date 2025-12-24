using WeatherForecast.Application.DTOs;
using WeatherForecast.Application.Mappers.Interface;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Application.Mappers;

public class SensorsMapper :
    IMapper<SensorsDTO, Sensors>,
    IMapper<Sensors, SensorsDTO>
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

    public Sensors Map(SensorsDTO source)
    {
        return new Sensors
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