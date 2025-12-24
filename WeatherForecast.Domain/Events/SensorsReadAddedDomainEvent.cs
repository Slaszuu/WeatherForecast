using MediatR;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Events.Interface;

namespace WeatherForecast.Domain.Events;

public record SensorsReadAddedDomainEvent(Sensors Sensors) : IDomainEvent, INotification;