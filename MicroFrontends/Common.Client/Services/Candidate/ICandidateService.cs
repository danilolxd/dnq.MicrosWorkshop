using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Client.Models.Candidate;
using Refit;

namespace Common.Client.Services.Candidate;

public interface ICandidateService
{
    [Get("/candidates/{idVacancy}")]
    Task<CandidateDetailResponse> GetAsync(int idVacancy);

    [Get("/candidates")]
    Task<List<CandidateListItemResponse>> ListAsync();
}
