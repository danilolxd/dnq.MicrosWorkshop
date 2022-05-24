using System;

namespace Company.WebUI.Models
{
    public class VacancyDetailViewModel
    {
        public int IdVacancy { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
    }
}