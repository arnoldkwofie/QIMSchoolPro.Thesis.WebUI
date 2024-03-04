using Microsoft.Extensions.Configuration;

using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QimSchoolPro.Thesis.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly string _baseRoute;
        private readonly IHttpRequestService _httpAccessorService;

        public AuthService(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _baseRoute = $"{configuration["ApplicationService:Master:TokenUrl"]}UserAccount";
            _httpAccessorService = httpRequestService;
        }

        public async Task<LoginResponseViewModel> LoginAsync(LoginCommand login)
        {
            try
            {
                string path = $"{_baseRoute}/login";
                var data = await _httpAccessorService.GetPostRequestAsync<LoginResponseViewModel>
                    (path, login, new CancellationToken());
                return data;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }


    }

    public interface IAuthService
    {
        Task<LoginResponseViewModel> LoginAsync(LoginCommand login);
    }
}
