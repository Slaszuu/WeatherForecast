using WeatherForecast.Persistence.Entities;

namespace WeatherForecast.Services.MeasurementsCalibrationService;

public interface IMeasurementsCalibrationService
{
    public Weather Calibrate(Sensors sensors);
}