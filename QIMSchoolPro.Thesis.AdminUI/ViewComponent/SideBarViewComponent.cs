using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.ViewComponent
{
    public class SideBarViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IUserService _userService;

        public SideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserViewModel user = await _userService.GetLoginUser();
            return View(user);
        }
    }
}
