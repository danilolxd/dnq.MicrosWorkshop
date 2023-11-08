using System;

namespace Common.Client.Models.Candidate;

public class CandidateDetailResponse
{
    public Guid IdCandidate { get; set; }
    public long IdVacancy { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}
