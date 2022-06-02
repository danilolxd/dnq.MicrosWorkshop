using Candidates.Domain.Events;
using Common.Domain;
using System;

namespace Candidates.Domain.Entities
{
    public class Candidate : Entity
    {
        public int IdCandidate { get; private set; }
        public int IdVacancy { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public DateTime InsertDate { get; private set; }

        public Candidate(int idVacancy, string name, string surname, string email)
        {
            IdVacancy = idVacancy;
            Name = name;
            Surname = surname;
            Email = email;
            InsertDate = DateTime.Now;

            AddDomainEvent(new CandidateAddedDomainEvent(this));
        }
    }
}