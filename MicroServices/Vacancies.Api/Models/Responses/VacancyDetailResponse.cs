using System;

namespace Vacancies.Api.Models.Responses
{
    public class VacancyDetailResponse
    {
        public int IdVacancy { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
    }
}