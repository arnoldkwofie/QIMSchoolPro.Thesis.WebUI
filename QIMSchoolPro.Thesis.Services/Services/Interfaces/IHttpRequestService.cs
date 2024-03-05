using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;

namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IHttpRequestService
    {
        Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken);
        Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken);
        Task<T> GetPostRequestAsync<T>(string path, object payload, CancellationToken cancellationToken);
        Task<RequestResponse> GetDeptReviewRequestAsync(string path, CancellationToken cancellationToken);
        Task<IAuthorityClaims> GetClaimsAsync();
        Task<RequestResponse> DeleteRequestAsync(string path, CancellationToken cancellationToken);
    }
}
