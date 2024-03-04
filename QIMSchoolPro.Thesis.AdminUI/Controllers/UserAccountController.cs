using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Authorization;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QimSchoolPro.Thesis.Services.Implementations;
using Newtonsoft.Json;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserAccountController(ILogger<UserAccountController> logger,
            IAuthService authService, IUserService userService,
            IConfiguration configuration)
        {
            _logger = logger;
            _authService = authService;
            _userService = userService;
            _configuration = configuration;
        }



        [AllowAnonymous]
        //[Route("Account/Login")]
        public ActionResult Login()
        {
            ViewBag.Subdomain = _configuration["Subdomain"].ToString();
            ViewBag.AppName = _configuration["AppName"].ToString();
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        //[Route("Account/AllowLogin")]
        [ValidateAntiForgeryToken] // Add anti-forgery validation
        public async Task<IActionResult> AllowLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                string token = await CallExternalTokenService(model.Username, model.Password);
                if (token != null)
                {
                    // Extract user information and claims from the external token
                    var (claimsIdentity, expirationTime) = ExtractClaimsFromExternalToken(token);

                    // Set the ClaimsPrincipal on HttpContext
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Manually add the token to the user's claims
                    var authenticationProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(expirationTime)
                    };

                    authenticationProperties.StoreTokens(new List<AuthenticationToken>
                    {
                        new AuthenticationToken { Name = "access_token", Value = token }
                    });

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal, authenticationProperties);


                    //Man is better you dont touch this
                    //await _userService.InitAsync(model.Username);


                    ViewBag.Message = "Login successful!";
                    //ViewBag.Claims = claimsPrincipal.Claims;
                    var serializerSettings = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };

                   
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    // Handle login failure
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View(model);
                }



            }
            return View(model);
        }

        private async Task<string> CallExternalTokenService(string username, string password)
        {
            var token = await _authService.LoginAsync(new LoginCommand
            {
                Username = username,
                Password = password,
            });
            return token.Token;
        }
        private (ClaimsIdentity ClaimsIdentity, long ExpirationTime) ExtractClaimsFromExternalToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            var claims = jsonToken.Claims;

            var nameClaim = claims.FirstOrDefault(a => a.Type == "unique_name");
            var roleClaims = claims.Where(a => a.Type == "role").Select(a => new Claim(ClaimTypes.Role, a.Value)).ToList();

            var idClaim = claims.FirstOrDefault(a => a.Type == "nameid");
            var emailClaim = claims.FirstOrDefault(a => a.Type == "email");
            var nbfClaim = claims.FirstOrDefault(a => a.Type == "nbf");
            var expClaim = claims.FirstOrDefault(a => a.Type == "exp");
            var iatClaim = claims.FirstOrDefault(a => a.Type == "iat");

            var allClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, nameClaim?.Value),
                        new Claim(ClaimTypes.NameIdentifier, idClaim?.Value),
                        new Claim(ClaimTypes.Email, emailClaim?.Value),
                        new Claim("nbf", nbfClaim?.Value),
                        new Claim("exp", expClaim?.Value),
                        new Claim("iat", iatClaim?.Value),
                    };


            allClaims.AddRange(roleClaims);

            var claimsIdentity = new ClaimsIdentity(allClaims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            if (expClaim != null && long.TryParse(expClaim.Value, out var expirationTime))
            {
                return (claimsIdentity, expirationTime);
            }
            throw new Exception("Invalid token");
        }


        //[Route("Account/Logout")]
        //[Authorize]

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");

        }


        public async Task<IActionResult> GetLoginUser()
        {
            UserViewModel user = await _userService.GetLoginUser();
            return View(user);
        }



    }
}
