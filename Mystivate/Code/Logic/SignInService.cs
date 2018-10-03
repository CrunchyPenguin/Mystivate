using Microsoft.AspNetCore.Http;
using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Mystivate.Code.Logic
{
    public class SignInService : ISignInService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignInService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool IsSignedIn()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            //if signincorrect
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
                IssuedUtc = DateTime.Now,
                RedirectUri = "./Info/Home"
            };

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return true;
        }

        public async Task SignOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }

}
