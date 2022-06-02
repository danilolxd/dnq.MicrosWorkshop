using Candidates.Application.IntegrationEvents;
using Candidates.Domain.Events;
using EventBus.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidates.Application.DomainEventHandlers
{
    public class PublishIntegrationEventDomainEventHandler : INotificationHandler<CandidateAddedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public PublishIntegrationEventDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task Handle(CandidateAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new CandidateAddedIntegrationEvent(notification.Candidate.IdCandidate, notification.Candidate.IdVacancy));
            return Task.CompletedTask;
        }
    }
}