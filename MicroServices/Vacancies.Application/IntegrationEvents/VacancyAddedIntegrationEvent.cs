using EventBus.Events;
using System;

namespace Vacancies.Application.IntegrationEvents
{
    public class VacancyAddedIntegrationEvent : IntegrationEvent
    {
        public int IdVacancy { get; private set; }
        public string Job { get; private set; }
        public string Description { get; private set; }
        public DateTime InsertDate { get; private set; }

        public VacancyAddedIntegrationEvent(int idVacancy, string job, string description, DateTime insertDate)
        {
            IdVacancy = idVacancy;
            Job = job;
            Description = description;
            InsertDate = insertDate;
        }
    }
}