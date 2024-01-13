using AutoMapper;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Base;

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
