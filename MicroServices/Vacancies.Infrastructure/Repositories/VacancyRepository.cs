using Common.Infrastructure;
using Vacancies.Application.Repositories.Contracts;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Contexts;

namespace Vacancies.Infrastructure.Repositories
{
    public class VacancyRepository : EFRepository<Vacancy, int>, IVacancyRepository
    {
        public VacancyRepository(VacancyContext dbContext) : base(dbContext)
        {
        }
    }
}