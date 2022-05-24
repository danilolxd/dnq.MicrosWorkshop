using Common.Client.Models.Vacancy;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Client.Services.Vacancy
{
    public interface IVacancyService
    {
        [Get("/vacancies/{idVacancy}")]
        Task<VacancyDetailResponse> GetAsync(int idVacancy);

        [Get("/vacancies")]
        Task<List<VacancyListItemResponse>> ListAsync();
    }
}