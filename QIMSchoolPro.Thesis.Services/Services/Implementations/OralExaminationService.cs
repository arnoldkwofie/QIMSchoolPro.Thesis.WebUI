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
    public class OralExaminationService : IOralExaminationService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public OralExaminationService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}OralExamination";
            _httpAccessorService = httpRequestService;
        }


       

        public async Task<RequestResponse> Schedule(ScheduleCommand payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.Schedule(_baseRoute), new { command=payload },
                new CancellationToken());
            return model;
        }

        public async Task<List<OralExaminationViewModel>> GetAll( )
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<OralExaminationViewModel>>(HttpUrlConstant.GetOralExaminations(_baseRoute),
                new CancellationToken());
            return model;
        }



    }
}
