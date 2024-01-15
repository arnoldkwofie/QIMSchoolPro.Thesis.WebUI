﻿using Microsoft.AspNetCore.Authentication.Cookies;
using QIMSchoolPro.Thesis.Services.Contracts;
using QIMSchoolPro.Thesis.Services.Services.Base;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace QIMSchoolPro.Thesis.Services.Services
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
            //service.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:7116"));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());


            service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IHttpRequestService, HttpRequestService>();
            service.AddScoped<ISubmissionService, SubmissionService>();
            service.AddScoped<IVersionService, VersionService>();
            service.AddScoped<IThesisAssignmentService, ThesisAssignmentService>();
            service.AddSingleton<ILocalStorageService, LocalStorageService>();
            service.AddScoped<IStaffService, StaffService>();


            return service;
        }
    }
}