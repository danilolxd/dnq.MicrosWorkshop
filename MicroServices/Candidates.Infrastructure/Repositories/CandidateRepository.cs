using Candidates.Application.Repositories.Contracts;
using Candidates.Domain.Entities;
using Candidates.Infrastructure.Contexts;
using Common.Infrastructure;

namespace Candidates.Infrastructure.Repositories
{
    public class CandidateRepository : EFRepository<Candidate, int>, ICandidateRepository
    {
        public CandidateRepository(CandidateContext dbContext) : base(dbContext)
        {
        }
    }
}