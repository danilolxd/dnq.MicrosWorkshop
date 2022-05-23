using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacancies.Api.Models.Requests;
using Vacancies.Api.Models.Responses;
using Vacancies.Api.Queries.Contracts;
using Vacancies.Application.Commands;

namespace Vacancies.Api.Controllers
{
    [ApiController]
    [Route("vacancies")]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVacancyQueries _vacancyQueries;

        public VacancyController(IMediator mediator, IVacancyQueries vacancyQueries)
        {
            _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            _vacancyQueries = vacancyQueries ?? throw new System.ArgumentNullException(nameof(vacancyQueries));
        }

        [HttpGet("{idVacancy}")]
        public async Task<ActionResult<VacancyDetailResponse>> GetVacancyAsync(int idVacancy) =>
            await _vacancyQueries.GetAsync(idVacancy);

        [HttpGet("")]
        public async Task<ActionResult<List<VacancyListItemResponse>>> ListVacanciesAsync() =>
            await _vacancyQueries.ListAsync();

        [HttpPost("")]
        public async Task<IActionResult> CreateVacancyAsync(CreateVacancyRequest createVacancyRequest)
        {
            await _mediator.Send(new CreateVacancyCommand(createVacancyRequest.Job, createVacancyRequest.Description));
            return Ok();
        }
    }
}