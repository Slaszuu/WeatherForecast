using UUIDNext;
using WeatherForecast.Domain.Events;
using WeatherForecast.Domain.Events.Interface;

namespace WeatherForecast.Domain.Entities;

public class Sensors
{
    private readonly List<IDomainEvent> _domainEvents = [];

    private Sensors()
    {
    }

    public Guid Id { get; init; } = Uuid.NewDatabaseFriendly(Database.PostgreSql);
    public DateTimeOffset Timestamp { get; init; }
    public double CpuTemperature { get; init; }
    public double Temperature { get; init; }
    public double Pressure { get; init; }
    public double Humidity { get; init; }
    public double Lux { get; init; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public static Sensors Create(DateTimeOffset timestamp, double cpuTemperature, double temperature, double humidity, double pressure,
        double lux)
    {
        var sensors = new Sensors
        {
            Timestamp = timestamp,
            CpuTemperature = cpuTemperature,
            Temperature = temperature,
            Pressure = pressure,
            Humidity = humidity,
            Lux = lux
        };

        sensors.AddDomainEvent(new SensorsReadAddedDomainEvent(sensors));

        return sensors;
    }
}