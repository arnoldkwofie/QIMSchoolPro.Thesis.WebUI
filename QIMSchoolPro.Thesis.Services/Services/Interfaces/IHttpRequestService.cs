﻿using QIMSchoolPro.Thesis.Services.Models.ServiceModels;

namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IHttpRequestService
    {
        Task<RequestResponse> PostRequestAsync<TPayload>(string path, TPayload payload, CancellationToken cancellationToken);
        Task<T> GetRequestAsync<T>(string path, CancellationToken cancellationToken);

        Task<RequestResponse> GetDeptReviewRequestAsync(string path, CancellationToken cancellationToken);
    }
}