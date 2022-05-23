using System.Collections.Generic;
using System.Threading.Tasks;
using Vacancies.Api.Models.Responses;

namespace Vacancies.Api.Queries.Contracts
{
    public interface IVacancyQueries
    {
        Task<VacancyDetailResponse> GetAsync(int idVacancy);
        Task<List<VacancyListItemResponse>> ListAsync();
    }
}