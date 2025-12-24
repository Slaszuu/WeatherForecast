namespace WeatherForecast.Application.Mappers.Interface;

public interface IMapper<in TSource, out TDestination>
{
    TDestination Map(TSource source);
}