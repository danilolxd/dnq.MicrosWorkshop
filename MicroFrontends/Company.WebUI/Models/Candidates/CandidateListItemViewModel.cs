using System;

namespace Company.WebUI.Models.Candidates;

public class CandidateListItemViewModel
{
    public Guid IdCandidate { get; set; }
    public long IdVacancy { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}
