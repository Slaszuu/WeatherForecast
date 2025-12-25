namespace WeatherForecast.Shared.Constants;

public static class Consts
{
    public const double TemperatureCalibrationOffset = 3.21;
    public const double HumidityCalibrationOffset = 9.97;
    public const double MagnusVaporA = 17.62;
    public const double MagnusVaporB = 243.12;

    public const string SignalRWeatherUpdatedMethod = "WeatherUpdated";
}