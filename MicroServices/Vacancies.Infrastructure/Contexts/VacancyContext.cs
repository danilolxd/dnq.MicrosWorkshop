using Common.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.ContextConfigurations;
using Vacancies.Infrastructure.Seeds;

namespace Vacancies.Infrastructure.Contexts
{
    public class VacancyContext : ContextBase
    {

        public DbSet<Vacancy> Vacancies { get; set; }

        public VacancyContext(DbContextOptions<VacancyContext> options) : base(options)
        {
        }

        public VacancyContext(DbContextOptions<VacancyContext> options, IMediator mediator) : base(options, mediator)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VacancyEntityTypeConfiguration());

            new VacancySeed().Seed(modelBuilder);
        }
    }
}