using AutoMapper;
using Common.Client.Models.Candidate;
using Common.Client.Models.Vacancy;
using Company.WebUI.Models.Candidates;
using Company.WebUI.Models.Vancancies;

namespace Company.WebUI.AutoMapper
{
    public class UIProfile : Profile
    {
        public UIProfile()
        {
            // vacancies
            CreateMap<VacancyDetailResponse, VacancyDetailViewModel>();
            CreateMap<VacancyListItemResponse, VacancyListItemViewModel>();

            // candidates
            CreateMap<CandidateDetailResponse, CandidateDetailViewModel>();
            CreateMap<CandidateListItemResponse, CandidateListItemViewModel>();
        }
    }
}