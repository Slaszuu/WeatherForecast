using WeatherForecast.Domain.Entities;
using WeatherForecast.Shared.Constants;

namespace WeatherForecast.Domain.Services.MeasurementsCalibrationService;

public class MeasurementsCalibrationService : IMeasurementsCalibrationService
{
    public Weather Calibrate(Sensors sensors)
    {
        var temperature = sensors.Temperature - Consts.TemperatureCalibrationOffset;
        var humidity = CalculateRealHumidity(sensors, temperature);

        return Weather.Create(
            id: sensors.Id,
            timestamp: sensors.Timestamp,
            temperature: temperature,
            humidity: humidity,
            pressure: sensors.Pressure,
            lux: sensors.Lux);
    }

    //ToDo hardware changes needed to ensure CPU is not heating temp sensors.
    private static double CalculateRealTemperature(Sensors sensors)
    {
        const double k = -0.5;
        const double kPositive = 0.05;

        var t = sensors.Temperature;

        if (t >= 0)
            return t - Consts.TemperatureCalibrationOffset + kPositive * t * t;

        return t - Consts.TemperatureCalibrationOffset + k * t * t;
    }

    private static double CalculateRealHumidity(Sensors sensors, double realTemperature)
    {
        const double belowZeroCorrection = 1.05;
        const double aboveZeroCorrection = 1.2;
        const double humidityOffset = 20.0;

        var deltaT = sensors.Temperature - realTemperature;
        var factor = Math.Exp(Consts.MagnusVaporA * deltaT / (Consts.MagnusVaporB + realTemperature));
        factor = Math.Min(factor, realTemperature < 0 ? belowZeroCorrection : aboveZeroCorrection);

        var humidity = sensors.Humidity * factor + humidityOffset;

        return Math.Clamp(humidity, 0.0, 100.0);
    }
}