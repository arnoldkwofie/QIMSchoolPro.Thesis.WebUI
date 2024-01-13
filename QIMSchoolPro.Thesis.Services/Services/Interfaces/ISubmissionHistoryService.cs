using QIMSchoolPro.Thesis.Services.Models.ViewModels;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface ISubmissionHistoryService 
    {
        Task<List<SubmissionHistoryViewModel>> GetSubmissionHistoryBySubmissionId(int id);
    }
}
