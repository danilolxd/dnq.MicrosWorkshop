using EventBus.Events;

namespace Vacancies.Application.IntegrationEvents
{
    public class CandidateAddedIntegrationEvent : IntegrationEvent
    {
        public int IdCandidate { get; private set; }
        public int IdVacancy { get; private set; }

        public CandidateAddedIntegrationEvent(int idCandidate, int idVacancy)
        {
            IdCandidate = idCandidate;
            IdVacancy = idVacancy;
        }
    }
}