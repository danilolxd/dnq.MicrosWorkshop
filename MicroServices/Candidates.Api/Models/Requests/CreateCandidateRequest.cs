using System.ComponentModel.DataAnnotations;

namespace Candidates.Api.Models.Requests
{
    public class CreateCandidateRequest
    {
        [Required]
        public int IdVacancy { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }
    }
}