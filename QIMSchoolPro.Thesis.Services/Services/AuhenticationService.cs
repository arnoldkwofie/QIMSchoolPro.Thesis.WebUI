﻿//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;

//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using AutoMapper;
//using IAuthenticationService = QIMSchoolPro.Thesis.Services.Contracts.IAuthenticationService;
//using QIMSchoolPro.Thesis.Services.Models.ViewModels;
//using QIMSchoolPro.Thesis.Services.Services.Base;
//using QIMSchoolPro.Thesis.Services.Contracts;
//using Microsoft.AspNetCore.Http;

//namespace QIMSchoolPro.Thesis.Services.Services
//{
//    public class AuthenticationService : BaseHttpService, IAuthenticationService
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly IMapper _mapper;
//        private JwtSecurityTokenHandler _tokenHandler;

//        public AuthenticationService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor,
//            IMapper mapper)
//            : base(client, localStorage)
//        {
//            this._httpContextAccessor = httpContextAccessor;
//            this._mapper = mapper;
//            this._tokenHandler = new JwtSecurityTokenHandler();
//        }

//        public async Task<bool> Authenticate(string email, string password)
//        {
//            try
//            {
//                AuthRequest authenticationRequest = new() { Email = email, Password = password };
//                var authenticationResponse = await _client.LoginAsync(authenticationRequest);

//                if (authenticationResponse.Token != string.Empty)
//                {
//                    //Get Claims from token and Build auth user object
//                    var tokenContent = _tokenHandler.ReadJwtToken(authenticationResponse.Token);
//                    var claims = ParseClaims(tokenContent);
//                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
//                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
//                    _localStorage.SetStorageValue("token", authenticationResponse.Token);
//                    //var d =  _localStorage.GetStorageValue<string>("token");
//                    return true;
//                }
//                return false;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<bool> Register(RegisterViewModel registration)
//        {

//            RegistrationRequest registrationRequest = _mapper.Map<RegistrationRequest>(registration);
//            var response = await _client.RegisterAsync(registrationRequest);

//            if (!string.IsNullOrEmpty(response.UserId))
//            {
//                await Authenticate(registration.Email, registration.Password);
//                return true;
//            }
//            return false;
//        }

//        public async Task Logout()
//        {
//            _localStorage.ClearStorage(new List<string> { "token" });
//            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//        }

//        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
//        {
//            var claims = tokenContent.Claims.ToList();
//            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
//            return claims;
//        }
//    }
//}
