using Common.Application;
using Vacancies.Domain.Entities;

namespace Vacancies.Application.Repositories.Contracts
{
    public interface IVacancyRepository : IRepository<Vacancy, int>
    {
    }
}