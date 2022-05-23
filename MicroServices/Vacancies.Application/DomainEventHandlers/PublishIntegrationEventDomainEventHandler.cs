using EventBus.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vacancies.Application.IntegrationEvents;
using Vacancies.Domain.Events;

namespace Vacancies.Application.DomainEventHandlers
{
    public class PublishIntegrationEventDomainEventHandler : INotificationHandler<VacancyAddedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public PublishIntegrationEventDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task Handle(VacancyAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new VacancyAddedIntegrationEvent(notification.Vacancy.IdVacancy, notification.Vacancy.Job, notification.Vacancy.Description, notification.Vacancy.InsertDate));
            return Task.CompletedTask;
        }
    }
}