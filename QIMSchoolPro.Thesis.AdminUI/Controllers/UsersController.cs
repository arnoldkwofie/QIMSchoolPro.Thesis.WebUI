﻿using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Contracts;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UsersController(IAuthenticationService authService)
        {
            this._authService = authService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            login.ReturnUrl = returnUrl;
            if (login != null)
            {
                var isLoggedIn = await _authService.Authenticate(login.Email, login.Password);
                if (isLoggedIn)
                {
                    returnUrl = Url.Content("~/Home/Index");
                    return LocalRedirect(returnUrl);
                }
                    
            }
            ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authService.Register(registration);
                if (isCreated)

                    return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "Registration Attempt Failed. Please try again.");
            return View(registration);
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            string returnUrl = Url.Content("~/");
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}