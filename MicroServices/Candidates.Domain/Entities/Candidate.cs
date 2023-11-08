using Common.Domain;

namespace Candidates.Domain.Entities;

public class Candidate : Entity
{
    // PK
    public Guid IdCandidate { get; set; }
    public long IdVacancy { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}
