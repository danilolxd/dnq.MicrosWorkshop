using Common.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Candidates.Domain.Entities;
using Candidates.Infrastructure.ContextConfigurations;

namespace Candidates.Infrastructure.Contexts
{
    public class CandidateContext : ContextBase
    {

        public DbSet<Candidate> Candidates { get; set; }

        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options)
        {
        }

        public CandidateContext(DbContextOptions<CandidateContext> options, IMediator mediator) : base(options, mediator)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateEntityTypeConfiguration());
        }
    }
}