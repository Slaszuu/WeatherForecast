namespace WeatherForecast.Mappers.Interface;

public interface IMapper<in TSource, out TDestination>
{
    TDestination Map(TSource source);
}