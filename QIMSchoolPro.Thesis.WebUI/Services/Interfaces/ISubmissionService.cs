using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;

namespace QIMSchoolPro.Thesis.WebUI.Services.Interfaces
{
    public interface ISubmissionService 
    {
        Task<RequestResponse> Create(SubmissionCommand payload);
    }
}
