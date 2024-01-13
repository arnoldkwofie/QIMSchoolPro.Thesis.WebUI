using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IVersionService 
    {
        Task<RequestResponse> Create(VersionCommand payload);
    }
}
