using Microsoft.Extensions.Configuration;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
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

        public async Task<RequestResponse> Delete(int id)
        {
            return await _httpAccessorService
                .DeleteRequestAsync(HttpUrlConstant.Delete(_baseRoute, id),
                new CancellationToken());
        }

        public async Task<RequestResponse> Create(SubmissionCommand payload)
        {
            var client = new RestClient(_baseRoute);
            var claims = await _httpAccessorService.GetClaimsAsync();
            var request = new RestRequest($"/Create", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("Authorization", "Bearer " + claims.Token, ParameterType.HttpHeader);
            if (payload.PrimaryFile != null)
                request.AddFile("PrimaryFile", payload.PrimaryFilePath ?? "");

            if (payload.ThesisForm != null)
                request.AddFile("ThesisForm", payload.ThesisFormPath ?? "");

            if (payload.SecondaryFile != null)
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


        public async Task<List<SubmissionViewModel>> GetUserSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetUserSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> GetDepartmentSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetDepartmentSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> GetLibrarySubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetLibrarySubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }
        public async Task<List<SubmissionViewModel>> DepartmentProcessedReviews()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.DepartmentProcessedReviews(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> SPSProcessedReviews()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.SPSProcessedReviews(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> GetReportSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetReportSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> GetStudentReportSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetStudentReportSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> GetDepartmentReportSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetDepartmentReportSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<ThesisAssignmentViewModel>> GetReviewerReportSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<ThesisAssignmentViewModel>>(HttpUrlConstant.GetReviewerReportSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<List<SubmissionViewModel>> GetSPSSubmissions()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionViewModel>>(HttpUrlConstant.GetSPSSubmissions(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<SubmissionViewModel> GetAsync(int id)
        {
            var model = await _httpAccessorService
                .GetRequestAsync<SubmissionViewModel>(HttpUrlConstant.Get(_baseRoute, id),
                new CancellationToken());
            return model;
        }

        public async Task<RequestResponse> Departmentapproval(int submissionId, int approvalId)
        {
            var model = await _httpAccessorService
                .GetDeptReviewRequestAsync(HttpUrlConstant.DepartmentApproval(_baseRoute, submissionId, approvalId),
                new CancellationToken());
            return model;
        }

        public async Task<RequestResponse> SubmitToLibrary(int id)
        {
            var model = await _httpAccessorService
                .GetDeptReviewRequestAsync(HttpUrlConstant.SubmitToLibrary(_baseRoute, id),
                new CancellationToken());
            return model;
        }


        public async Task<RequestResponse> PostSubmission(PostSubmission payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.PostSubmission(_baseRoute), new { payload },
                new CancellationToken());
            return model;
        }

        public async Task<RequestResponse> Publish(PublishCommand payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.Publish(_baseRoute), payload ,
                new CancellationToken());
            return model;
        }
        public async Task<RequestResponse> Decide(DecisionCommand payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.Decide(_baseRoute),  payload ,
                new CancellationToken());
            return model;
        }


    }
}
