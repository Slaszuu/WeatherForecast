using MediatR;
using WeatherForecast.Domain.Events.Interface;

namespace WeatherForecast.Application.DomainEventsDispatcher;

public class DomainEventsDispatcher(IMediator mediator) : IDomainEventsDispatcher
{
    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }
}