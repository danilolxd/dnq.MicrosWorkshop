using AutoMapper;
using Common.Client.Services.Candidate;
using Company.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.WebUI.Controllers
{
    [Route("candidate")]
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService ?? throw new System.ArgumentNullException(nameof(candidateService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var candidate = await _candidateService.GetAsync(id);
            return View(_mapper.Map<CandidateDetailViewModel>(candidate));
        }

        [Route("list/{id}")]
        public async Task<IActionResult> List(int id)
        {
            var vacancies = await _candidateService.ListAsync(id);
            return View(_mapper.Map<List<CandidateListItemViewModel>>(vacancies));
        }
    }
}