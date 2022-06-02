namespace Common.Client.Models.Candidate
{
    public class CandidateListItemResponse
    {
        public int IdCandidate { get; set; }
        public int IdVacancy { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}