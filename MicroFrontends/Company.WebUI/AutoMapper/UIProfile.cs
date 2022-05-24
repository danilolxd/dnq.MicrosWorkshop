using AutoMapper;
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
        }
    }
}