using System;

namespace Company.WebUI.Models
{
    public class CandidateDetailViewModel
    {
        public int IdCandidate { get; set; }
        public int IdVacancy { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
    }
}