using Common.Client.Models.Candidate;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Client.Services.Candidate
{
    public interface ICandidateService
    {
        [Get("/candidates/{idCandidate}")]
        Task<CandidateDetailResponse> GetAsync(int idCandidate);

        [Get("/candidates")]
        Task<List<CandidateListItemResponse>> ListAsync(int idVacancy);
    }
}