using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using QIMSchoolPro.Thesis.WebUI.Contracts;
using QIMSchoolPro.Thesis.WebUI.Services.Base;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;
using System.Reflection;

namespace QIMSchoolPro.Thesis.WebUI.Services
{
    public static class RegisterService
    {
        public static IServiceCollection AddHttpRequestService(this IServiceCollection service)
        {

            service.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/users/login");
                });



            service.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:7295"));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());


            service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IHttpRequestService, HttpRequestService>();
            service.AddScoped<ISubmissionService, SubmissionService>();
            service.AddScoped<IVersionService, VersionService>();
            service.AddSingleton<ILocalStorageService, LocalStorageService>();


            return service;
        }
    }
}
