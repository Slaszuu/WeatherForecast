using WeatherForecast.Domain.Events.Interface;

namespace WeatherForecast.Application.DomainEventsDispatcher;

public interface IDomainEventsDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
    Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}