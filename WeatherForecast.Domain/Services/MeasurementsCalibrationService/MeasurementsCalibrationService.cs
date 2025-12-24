using WeatherForecast.Domain.Entities;
using WeatherForecast.Shared.Constants;

namespace WeatherForecast.Domain.Services.MeasurementsCalibrationService;

public class MeasurementsCalibrationService : IMeasurementsCalibrationService
{
    public Weather Calibrate(Sensors sensors)
    {
        var temperature = CalculateRealTemperature(sensors);
        var humidity = CalculateRealHumidity(sensors, temperature);

        return Weather.Create(
            id: sensors.Id,
            timestamp: sensors.Timestamp,
            temperature: temperature,
            humidity: humidity,
            pressure: sensors.Pressure,
            lux: sensors.Lux);
    }

    private static double CalculateRealTemperature(Sensors sensors) =>
        sensors.Temperature - Consts.TemperatureCalibrationOffset;

    private static double CalculateRealHumidity(Sensors sensors, double realTemperature)
    {
        var deltaT = sensors.Temperature - realTemperature;
        var humidity =
            sensors.Humidity
            * Math.Exp(Consts.MagnusVaporA * deltaT / (Consts.MagnusVaporB + realTemperature))
            + Consts.HumidityCalibrationOffset;
        return Math.Clamp(humidity, 0.0, 100.0);
    }
}