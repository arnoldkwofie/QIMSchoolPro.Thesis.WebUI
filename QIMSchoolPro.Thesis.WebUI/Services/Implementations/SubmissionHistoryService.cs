using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Models.ServiceModels;
using QIMSchoolPro.Thesis.WebUI.Models.ViewModels;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;
using RestSharp;
using System.Net;
using System.Threading;

namespace QIMSchoolPro.Thesis.WebUI.Services.Implementations
{
    public class SubmissionHistoryService : ISubmissionHistoryService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public SubmissionHistoryService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}SubmissionHistory";
            _httpAccessorService = httpRequestService;
        }

       
        public async Task<List<SubmissionHistoryViewModel>> GetSubmissionHistoryBySubmissionId(int id)
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<SubmissionHistoryViewModel>>(HttpUrlConstant.GetSubmissionHistoryBySubmissionId(_baseRoute, id),
                new CancellationToken());
            return model;
        }

        //public async Task<SubmissionViewModel> GetAsync(int id)
        //{
        //    var model = await _httpAccessorService
        //        .GetRequestAsync<SubmissionViewModel>(HttpUrlConstant.Get(_baseRoute, id),
        //        new CancellationToken());
        //    return model;
        //}
    }
}
