using Common.Domain;
using Vacancies.Domain.Entities;

namespace Vacancies.Domain.Events
{
    public class VacancyAddedDomainEvent : DomainEvent
    {
        public Vacancy Vacancy { get; private set; }

        public VacancyAddedDomainEvent(Vacancy vacancy)
        {
            Vacancy = vacancy;
        }
    }
}