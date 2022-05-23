using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.ContextConfigurations
{
    class VacancyEntityTypeConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.ToTable("vacancies");
            builder.HasKey(b => b.IdVacancy);
            builder.Ignore(b => b.DomainEvents);
        }
    }
}