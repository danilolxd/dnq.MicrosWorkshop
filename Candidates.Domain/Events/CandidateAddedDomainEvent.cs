using Candidates.Domain.Entities;
using Common.Domain;

namespace Candidates.Domain.Events
{
    public class CandidateAddedDomainEvent : DomainEvent
    {
        public Candidate Candidate { get; private set; }

        public CandidateAddedDomainEvent(Candidate candidate)
        {
            Candidate = candidate;
        }
    }
}
