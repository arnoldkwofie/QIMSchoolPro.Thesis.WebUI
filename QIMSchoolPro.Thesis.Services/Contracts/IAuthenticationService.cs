using QIMSchoolPro.Thesis.Services.Models.ViewModels;

namespace QIMSchoolPro.Thesis.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterViewModel registration);
        Task Logout();
    }
}
