using Candidates.Domain.Entities;
using Common.Application;

namespace Candidates.Application.Repositories.Contracts
{
    public interface ICandidateRepository : IRepository<Candidate, int>
    {
    }
}