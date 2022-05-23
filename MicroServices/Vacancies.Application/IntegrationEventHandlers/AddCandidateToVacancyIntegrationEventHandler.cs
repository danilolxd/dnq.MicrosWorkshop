using EventBus.Abstractions;
using MediatR;
using System;
using System.Threading.Tasks;
using Vacancies.Application.Commands;
using Vacancies.Application.IntegrationEvents;

namespace Vacancies.Application.IntegrationEventHandlers
{
    public class AddCandidateToVacancyIntegrationEventHandler : IIntegrationEventHandler<CandidateAddedIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public AddCandidateToVacancyIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(CandidateAddedIntegrationEvent @event) =>
            await _mediator.Send(new AddCandidateToVacancyCommand(@event.IdVacancy));
    }
}