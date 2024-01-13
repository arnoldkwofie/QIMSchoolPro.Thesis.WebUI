using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface ISubmissionService 
    {
        Task<RequestResponse> Create(SubmissionCommand payload);
        Task<List<SubmissionViewModel>> GetUserSubmissions();
        Task<SubmissionViewModel> GetAsync(int id);
        Task<RequestResponse> PostSubmission(PostSubmission coomand);
    }
}
