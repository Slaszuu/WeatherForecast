using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Services.MeasurementsCalibrationService;

public interface IMeasurementsCalibrationService
{
    public Weather Calibrate(Sensors sensors);
}