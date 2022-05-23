using MediatR;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
    [Serializable]
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }
    }
}