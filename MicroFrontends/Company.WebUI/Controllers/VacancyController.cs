using AutoMapper;
using Common.Client.Services.Vacancy;
using Company.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.WebUI.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public VacancyController(IVacancyService vacancyService, IMapper mapper)
        {
            _vacancyService = vacancyService ?? throw new System.ArgumentNullException(nameof(vacancyService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vacancy = await _vacancyService.GetAsync(id);
            return View(_mapper.Map<VacancyDetailViewModel>(vacancy));
        }

        [Route("")]
        public async Task<IActionResult> List()
        {
            var vacancies = await _vacancyService.ListAsync();
            return View(_mapper.Map<List<VacancyListItemViewModel>>(vacancies));
        }
    }
}