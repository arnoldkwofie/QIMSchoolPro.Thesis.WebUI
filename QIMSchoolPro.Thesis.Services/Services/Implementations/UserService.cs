using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace QimSchoolPro.Thesis.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly string _baseRoute;
        private readonly string _baseApplicationRoute;
        private readonly IConfiguration _configuration;
        private readonly IHttpRequestService _httpAccessorService;
        private readonly ILogger<UserService> _logger;

        public UserService(IConfiguration configuration, IHttpRequestService httpRequestService, ILogger<UserService> logger)
        {
            _configuration = configuration;

            //_baseRoute = $"{configuration["ApplicationService:Authentication:BaseUrl"]}";
            _baseApplicationRoute = $"{configuration["ApplicationService:Master:BaseUrl"]}";
            _httpAccessorService = httpRequestService;
            _logger = logger;
        }



        public async Task<UserViewModel> GetLoginUser()
        {
            try
            {
                _logger.LogInformation("User Service Started");

                var app = _configuration["ApplicationService:AppName"];
                _logger.LogInformation($"Login Client: {app}");

                string path = $"{_baseApplicationRoute}Account/UserInfo/";
                var userViewModel = await _httpAccessorService.GetRequestAsync<UserViewModel>(path, new CancellationToken());
                _logger.LogInformation($"Login user is:{userViewModel.Email}");

                return userViewModel;

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);

                return UserViewModel.Default();
            }
        }
        //public async Task InitAsync(string id)
        //{
        //    try
        //    {

        //        await _httpAccessorService.GetRequestAsync<object>($"{_baseApplicationRoute}Account/init?id={id}", new CancellationToken());


        //    }
        //    catch (System.Exception ex)
        //    {
        //        _logger.LogError(ex.Message);

        //    }
        //}

    }
}
