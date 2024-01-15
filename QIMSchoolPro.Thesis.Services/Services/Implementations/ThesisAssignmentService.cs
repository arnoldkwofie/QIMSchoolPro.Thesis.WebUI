﻿using Microsoft.Extensions.Configuration;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using RestSharp;
using System.Net;
using System.Threading;

namespace QIMSchoolPro.Thesis.WebUI.Services.Implementations
{
    public class ThesisAssignmentService : IThesisAssignmentService
	{
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;
        public ThesisAssignmentService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}ThesisAssignment";
            _httpAccessorService = httpRequestService;
        }

     
        public async Task<List<ThesisAssignmentViewModel>> GetAssignmentByStaffId(string id)
        {
            var model = await _httpAccessorService
                .GetRequestAsync<List<ThesisAssignmentViewModel>>(HttpUrlConstant.GetByStaffId(_baseRoute, id),
                new CancellationToken());
            return model;
        }

        public async Task<RequestResponse> AssignThesis(ThesisAssignmentCommand payload)
        {
            var model = await _httpAccessorService
                .PostRequestAsync(HttpUrlConstant.Create(_baseRoute), new { payload },
                new CancellationToken());
            return model;
        }



    }
}