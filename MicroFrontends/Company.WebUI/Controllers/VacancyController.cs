using AutoMapper;
using Common.Client.Services.Vacancy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Client.Models.Vacancy;
using Company.WebUI.Models.Vancancies;

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
            VacancyDetailResponse vacancy = await _vacancyService.GetAsync(id);
            VacancyDetailViewModel vacancyDetailViewModel = _mapper.Map<VacancyDetailViewModel>(vacancy);
            return View(vacancyDetailViewModel);
        }

        [Route("")]
        public async Task<IActionResult> List()
        {
            List<VacancyListItemResponse> vacancies = await _vacancyService.ListAsync();
            List<VacancyListItemViewModel> vacancyListItemViewModels = _mapper.Map<List<VacancyListItemViewModel>>(vacancies);
            return View(vacancyListItemViewModels);
        }
    }
}