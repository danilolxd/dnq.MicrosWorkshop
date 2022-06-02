using Candidates.Api.Models.Requests;
using Candidates.Api.Models.Responses;
using Candidates.Api.Queries.Contracts;
using Candidates.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidates.Api.Controllers
{
    [ApiController]
    [Route("candidates")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICandidateQueries _candidateQueries;

        public CandidateController(IMediator mediator, ICandidateQueries candidateQueries)
        {
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            _candidateQueries = candidateQueries ?? throw new System.ArgumentNullException(nameof(candidateQueries));
        }

        [HttpGet("{idCandidate}")]
        public async Task<ActionResult<CandidateDetailResponse>> GetCandidateAsync(int idCandidate) =>
            await _candidateQueries.GetAsync(idCandidate);

        [HttpGet("")]
        public async Task<ActionResult<List<CandidateListItemResponse>>> ListCandidatesAsync(int idVacancy) =>
            await _candidateQueries.ListAsync(idVacancy);

        [HttpPost("")]
        public async Task<IActionResult> CreateCandidateAsync(CreateCandidateRequest createCandidateRequest)
        {
            await _mediator.Send(new CreateCandidateCommand(createCandidateRequest.IdVacancy, createCandidateRequest.Name, createCandidateRequest.Surname, createCandidateRequest.Email));
            return Ok();
        }
    }
}