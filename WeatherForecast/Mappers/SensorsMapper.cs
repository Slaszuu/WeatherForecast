using WeatherForecast.DTOs;
using WeatherForecast.Mappers.Interface;
using WeatherForecast.Persistence.Entities;
using WeatherForecast.RequestModels;

namespace WeatherForecast.Mappers;

public class SensorsMapper : 
    IMapper<EspRequest, SensorsDTO>,
    IMapper<SensorsDTO, Sensors>
{
    public SensorsDTO Map(EspRequest source)
    {
        return new SensorsDTO
        {
            Timestamp = source.Time,
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
            Temperature = source.Temperature,
            Pressure = source.Pressure,
            Humidity = source.Humidity,
            Lux = source.Lux,
        };
    }
}
