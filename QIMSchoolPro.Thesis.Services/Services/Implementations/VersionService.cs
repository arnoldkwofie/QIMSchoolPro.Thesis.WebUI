using Microsoft.Extensions.Configuration;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using RestSharp;
using System.Net;
using System.Threading;

namespace QIMSchoolPro.Thesis.WebUI.Services.Implementations
{
    public class VersionService : IVersionService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public VersionService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}Version";
            _httpAccessorService = httpRequestService;
        }

        public async Task<RequestResponse> Delete(int id)
        {
            return await _httpAccessorService
                .DeleteRequestAsync(HttpUrlConstant.Delete(_baseRoute, id),
                new CancellationToken());
        }

        public async Task<RequestResponse> Create(VersionCommand payload)
        {
            var client = new RestClient(_baseRoute);
            var claims = await _httpAccessorService.GetClaimsAsync();
            var request = new RestRequest($"/Create", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("Authorization", "Bearer " + claims.Token, ParameterType.HttpHeader);
            if (payload.File != null)
                request.AddFile("File", payload.FilePath ?? "");
            request.AddParameter("DocumentId", payload.DocumentId);
           
            
            var response = await client.PostAsync(request);
           // var response = await client.ExecuteAsync<object>(request);
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


   
    }
}
