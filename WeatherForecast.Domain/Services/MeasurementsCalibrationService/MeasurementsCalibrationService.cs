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

    private static double CalculateRealTemperature(Sensors sensors)
    {
        const double k = -0.5;

        var t = sensors.Temperature;

        var calibrated = t - Consts.TemperatureCalibrationOffset + k * t * t;

        return calibrated;
    }

    private static double CalculateRealHumidity(Sensors sensors, double realTemperature)
    {
        const double belowZeroCorrection = 1.05;
        const double aboveZeroCorrection = 1.2;

        var deltaT = sensors.Temperature - realTemperature;

        // Magnus–Tetens factor
        var factor = Math.Exp(Consts.MagnusVaporA * deltaT / (Consts.MagnusVaporB + realTemperature));

        factor = Math.Min(factor, realTemperature < 0 ? belowZeroCorrection : aboveZeroCorrection);

        var humidity = sensors.Humidity * factor;

        return Math.Clamp(humidity, 0.0, 100.0);
    }
}