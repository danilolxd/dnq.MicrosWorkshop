using Candidates.Api.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidates.Api.Queries.Contracts
{
    public interface ICandidateQueries
    {
        Task<CandidateDetailResponse> GetAsync(int idCandidate);
        Task<List<CandidateListItemResponse>> ListAsync(int idVacancy);
    }
}