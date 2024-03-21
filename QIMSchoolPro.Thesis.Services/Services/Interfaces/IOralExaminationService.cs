using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IGradeService 
    {
        Task<List<GradeParamViewModel>> GetGradeParams();
        Task<RequestResponse> SaveGrade(List<GradeCommand> payload);
        Task<RequestResponse> UploadReport(UploadCommand payload);
    }
}
