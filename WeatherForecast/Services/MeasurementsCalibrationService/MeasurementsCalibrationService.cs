using WeatherForecast.Constants;
using WeatherForecast.Persistence.Entities;

namespace WeatherForecast.Services.MeasurementsCalibrationService;

public class MeasurementsCalibrationService : IMeasurementsCalibrationService
{
    public Weather Calibrate(Sensors sensors)
    {
        var temperature = CalculateRealTemperature(sensors);
        var humidity = CalculateRealHumidity(sensors, temperature);

        return new Weather
        {
            Id = sensors.Id,
            Timestamp = sensors.Timestamp,
            Temperature = temperature,
            Pressure = sensors.Pressure,
            Humidity = humidity,
            Lux = sensors.Lux,
        };
    }

    private static double CalculateRealTemperature(Sensors sensors) =>
        sensors.Temperature - Consts.TemperatureCalibrationOffset;

    private static double CalculateRealHumidity(Sensors sensors, double realTemperature)
    {
        var deltaT = sensors.Temperature - realTemperature;
        var humidity =
            sensors.Humidity *
            Math.Exp(Consts.MagnusVaporA * deltaT / (Consts.MagnusVaporB + realTemperature));
        return Math.Clamp(humidity, 0.0, 100.0);
    }
}