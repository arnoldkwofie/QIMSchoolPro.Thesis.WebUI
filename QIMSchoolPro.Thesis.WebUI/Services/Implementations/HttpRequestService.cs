using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;
using RestSharp;
using System.Net;

namespace QIMSchoolPro.Thesis.WebUI.Services.Implementations
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpRequestService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(path, Method.Post);
                request.AddBody( payload, null);
                //var claims = await GetClaimsAsync();
                //request.AddHeader("Authorization", "Bearer " + claims.Token);
                var response = await client.ExecuteAsync<object>(request, cancellationToken);
                if (response.IsSuccessful)
                {
                    return RequestResponse.Done("Added Successfully");
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        return RequestResponse.BadRequest(response.Content.Replace("\\", " "));
                    }
                    else
                    {
                        return RequestResponse.Error(response.ErrorMessage, response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(ex);
            }
        }
    }
}
