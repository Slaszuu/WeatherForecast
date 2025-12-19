using WeatherForecast.DTOs;
using WeatherForecast.Persistence.Entities;
using WeatherForecast.RequestModels;

namespace WeatherForecast.Mappers;

public static class SensorsMapper
{
    public static SensorsDTO ToDto(EspRequest request)
    {
        return new SensorsDTO
        {
            Timestamp = request.Time,
            Temperature = request.Temperature,
            Pressure = request.Pressure,
            Humidity = request.Humidity,
            Lux = request.Lux,
        };
    }
    
    public static Sensors ToEntity(SensorsDTO dto)
    {
        return new Sensors
        {
            Timestamp = dto.Timestamp,
            Temperature = dto.Temperature,
            Pressure = dto.Pressure,
            Humidity = dto.Humidity,
            Lux = dto.Lux,
        };
    }
}
