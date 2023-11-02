using AutoMapper;
using QIMSchoolPro.Thesis.WebUI.Models.ViewModels;
using QIMSchoolPro.Thesis.WebUI.Services.Base;

namespace QIMSchoolPro.Thesis.WebUI
{
    public class MappingProfile : Profile
    {
	    public MappingProfile()
	    {

		    CreateMap<RegisterViewModel, RegistrationRequest>().ReverseMap();
	    }
    }
}
