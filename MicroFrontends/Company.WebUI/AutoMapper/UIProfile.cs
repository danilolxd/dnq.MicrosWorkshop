using AutoMapper;
using Common.Client.Models.Candidate;
using Common.Client.Models.Vacancy;
using Company.WebUI.Models;

namespace Company.WebUI.AutoMapper
{
    public class UIProfile : Profile
    {
        public UIProfile()
        {
            CreateMap<VacancyDetailResponse, VacancyDetailViewModel>();
            CreateMap<VacancyListItemResponse, VacancyListItemViewModel>();

            CreateMap<CandidateDetailResponse, CandidateDetailViewModel>();
            CreateMap<CandidateListItemResponse, CandidateListItemViewModel>();
        }
    }
}