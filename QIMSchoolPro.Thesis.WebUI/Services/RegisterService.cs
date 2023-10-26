using Microsoft.AspNetCore.Cors.Infrastructure;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;

namespace QIMSchoolPro.Thesis.WebUI.Services
{
    public static class RegisterService
    {
        public static IServiceCollection AddHttpRequestService(this IServiceCollection service)
        {

            service.AddScoped<IHttpRequestService, HttpRequestService>();
            service.AddScoped<ISubmissionService, SubmissionService>();
          

            return service;
        }
    }
}
