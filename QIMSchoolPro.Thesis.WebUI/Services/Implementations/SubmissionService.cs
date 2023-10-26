using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;
using RestSharp;
using System.Net;
using System.Threading;

namespace QIMSchoolPro.Thesis.WebUI.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public SubmissionService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}Submission";
            _httpAccessorService = httpRequestService;
        }

        //public async Task<RequestResponse> Create(SubmissionCommand payload)
        //{
        //    return await _httpAccessorService
        //        .PostRequestAsync(HttpUrlConstant.Create(_baseRoute),  payload ,
        //        new CancellationToken());
        //}  
        
        public async Task<RequestResponse> Create(SubmissionCommand payload)
        {
            var client = new RestClient(_baseRoute);
            //var claims = await _httpAccessorService.GetClaimsAsync();
            var request = new RestRequest($"/Create", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            //request.AddParameter("Authorization", "Bearer " + claims.Token, ParameterType.HttpHeader);
            if (payload.PrimaryFile != null)
                request.AddFile("PrimaryFile", payload.PrimaryFilePath ?? "");
            request.AddFile("SecondaryFile", payload.SecondaryFilePath ?? "");
            request.AddParameter("Title", payload.Title);
            request.AddParameter("Abstract", payload.Abstract);
            request.AddParameter("StudentNumber", payload.StudentNumber);
            
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
