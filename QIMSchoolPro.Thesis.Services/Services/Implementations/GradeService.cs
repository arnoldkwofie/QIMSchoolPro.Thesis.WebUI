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
    public class GradeService : IGradeService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public GradeService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}Grade";
            _httpAccessorService = httpRequestService;
        }


        public async Task<List<GradeParamViewModel>> GetGradeParams()
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<GradeParamViewModel>>(HttpUrlConstant.GetGradeParams(_baseRoute),
                new CancellationToken());
            return model;
        }

        public async Task<RequestResponse> SaveGrade(List<GradeCommand> payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.SaveGrade(_baseRoute), new { payload },
                new CancellationToken());
            return model;
        }

        public async Task<RequestResponse> UploadReport(UploadCommand payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.UploadReport(_baseRoute), new { payload },
                new CancellationToken());
            return model;
        }



    }
}
