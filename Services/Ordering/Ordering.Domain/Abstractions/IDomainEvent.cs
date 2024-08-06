﻿namespace Ordering.Domain.Abstractions;

public interface IDomainEvent : INotification //created due to use mediatR library
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName; 
}
