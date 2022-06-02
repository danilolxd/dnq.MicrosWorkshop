using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Candidates.Domain.Entities;

namespace Candidates.Infrastructure.ContextConfigurations
{
    class CandidateEntityTypeConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidates");
            builder.HasKey(b => b.IdCandidate);
            builder.Ignore(b => b.DomainEvents);
        }
    }
}