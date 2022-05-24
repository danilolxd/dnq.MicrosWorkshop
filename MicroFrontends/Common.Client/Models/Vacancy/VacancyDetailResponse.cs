using System;

namespace Common.Client.Models.Vacancy
{
    public class VacancyDetailResponse
    {
        public int IdVacancy { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
    }
}