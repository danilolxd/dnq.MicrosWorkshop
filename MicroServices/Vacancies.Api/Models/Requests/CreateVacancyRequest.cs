using System.ComponentModel.DataAnnotations;

namespace Vacancies.Api.Models.Requests
{
    public class CreateVacancyRequest
    {
        [Required]
        public string Job { get; set; }

        [Required]
        public string Description { get; set; }
    }
}