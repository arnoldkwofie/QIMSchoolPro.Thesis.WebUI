using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;
using QIMSchoolPro.Thesis.WebUI.Models.ViewModels;

namespace QIMSchoolPro.Thesis.WebUI.Services.Interfaces
{
    public interface ISubmissionService 
    {
        Task<RequestResponse> Create(SubmissionCommand payload);
        Task<List<SubmissionViewModel>> GetUserSubmissions();
        Task<SubmissionViewModel> GetAsync(int id);
        Task<RequestResponse> PostSubmission(PostSubmission coomand);
    }
}
