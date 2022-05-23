using Common.Domain;
using System;
using Vacancies.Domain.Events;

namespace Vacancies.Domain.Entities
{
    public class Vacancy : Entity
    {
        public int IdVacancy { get; private set; }
        public string Job { get; private set; }
        public string Description { get; private set; }
        public int NumCandidates { get; private set; }
        public DateTime InsertDate { get; private set; }

        public Vacancy(string job, string description)
        {
            Job = job;
            Description = description;
            NumCandidates = 0;
            InsertDate = DateTime.Now;

            AddDomainEvent(new VacancyAddedDomainEvent(this));
        }

        public void AddCandidate() => NumCandidates++;
    }
}