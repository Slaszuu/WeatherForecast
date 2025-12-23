#region

using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence.Entities;
using WeatherForecast.RequestModels;

#endregion

namespace WeatherForecast.Mappers;

public class SensorsMapper :
    IMapper<EspRequest, SensorsDTO>,
    IMapper<SensorsDTO, Sensors>,
    IMapper<Sensors, SensorsDTO>
{
    public SensorsDTO Map(EspRequest source)
    {
        return new SensorsDTO
        {
            Timestamp = source.Time,
            CpuTemperature = source.CpuTemperature,
            Temperature = source.Temperature,
            Pressure = source.Pressure,
            Humidity = source.Humidity,
            Lux = source.Lux,
        };
    }

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