using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Client.Models.Candidate;
using Common.Client.Models.Vacancy;
using Common.Client.Services.Candidate;
using Company.WebUI.Models.Candidates;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebUI.Controllers;

public class CandidateController : Controller
{
    private readonly ICandidateService _candidateService;
    private readonly IMapper _mapper;

    public CandidateController(
        ICandidateService candidateService,
        IMapper mapper)
    {
        _candidateService = candidateService ?? throw new System.ArgumentNullException(nameof(candidateService));
        _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
    }

    [Route("candidates/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        CandidateDetailResponse candidate = await _candidateService.GetAsync(id);
        CandidateDetailViewModel candidateDetailViewModel = _mapper.Map<CandidateDetailViewModel>(candidate);
        return View(candidateDetailViewModel);
    }

    [Route("candidates")]
    public async Task<IActionResult> List()
    {
        List<CandidateListItemResponse> candidates = await _candidateService.ListAsync();
        List<CandidateListItemViewModel> candidateListItemResponses = _mapper.Map<List<CandidateListItemViewModel>>(candidates);
        return View(candidateListItemResponses);
    }
}
