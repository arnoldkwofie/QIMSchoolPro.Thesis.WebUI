using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;
using QIMSchoolPro.Thesis.WebUI.Models.ViewModels;

namespace QIMSchoolPro.Thesis.WebUI.Services.Interfaces
{
    public interface IVersionService 
    {
        Task<RequestResponse> Create(VersionCommand payload);
    }
}
