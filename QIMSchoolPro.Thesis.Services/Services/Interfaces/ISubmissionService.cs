using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface ISubmissionService 
    {
        Task<RequestResponse> Create(SubmissionCommand payload);
        Task<RequestResponse> Publish(PublishCommand payload);
        Task<RequestResponse> Decide(DecisionCommand payload);
        Task<List<SubmissionViewModel>> GetUserSubmissions();
        Task<SubmissionViewModel> GetAsync(int id);
        Task<RequestResponse> PostSubmission(PostSubmission coomand);
        Task<List<SubmissionViewModel>> GetDepartmentSubmissions();
        Task<List<SubmissionViewModel>> DepartmentProcessedReviews();
        Task<List<SubmissionViewModel>> GetSPSSubmissions();
        Task<List<SubmissionViewModel>> SPSProcessedReviews();
        Task<List<SubmissionViewModel>> GetReportSubmissions();
        Task<List<SubmissionViewModel>> GetStudentReportSubmissions();
        Task<List<SubmissionViewModel>> GetDepartmentReportSubmissions();
        Task<List<ThesisAssignmentViewModel>> GetReviewerReportSubmissions();
        Task<RequestResponse> Departmentapproval(int submissionId, int approvalId);
        Task<RequestResponse> Delete(int id);
    }
}
