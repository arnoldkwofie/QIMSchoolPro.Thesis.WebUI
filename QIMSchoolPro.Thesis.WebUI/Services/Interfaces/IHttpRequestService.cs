using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;

namespace QIMSchoolPro.Thesis.WebUI.Services.Interfaces
{
    public interface IHttpRequestService
    {
        Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken);
    }
}
