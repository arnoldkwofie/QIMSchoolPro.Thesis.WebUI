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
    public class StaffService : IStaffService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public StaffService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}Staff";
            _httpAccessorService = httpRequestService;
        }


        public async Task<List<StaffLookupViewModel>> StaffLookup(int id)
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<StaffLookupViewModel>>(HttpUrlConstant.StaffLookup(_baseRoute, id),
                new CancellationToken());
            return model;
        }



    }
}
