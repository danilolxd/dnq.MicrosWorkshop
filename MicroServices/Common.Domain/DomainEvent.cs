using MediatR;
using System;

namespace Common.Domain
{
    public abstract class DomainEvent : INotification
    {
        public DateTime EventDate { get; private set; }

        public DomainEvent()
        {
            EventDate = DateTime.Now;
        }
        public DomainEvent(DateTime eventDate)
        {
            EventDate = eventDate;
        }
    }
}