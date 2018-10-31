using Microsoft.AspNetCore.Http;
using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Mystivate.Data;

namespace Mystivate.Logic
{
    public class SignInService : ISignInService, IRegisterService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountAccess _accountAccess;

        public SignInService(IHttpContextAccessor httpContextAccessor, IAccountAccess accountAccess)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountAccess = accountAccess;
        }

        public RegisterResult RegisterUser(RegisterModel user)
        {
            if (!_accountAccess.UserExists(user.Email, user.Username))
            {
                EncryptedPassword encryptPass = PasswordEncryptor.EncryptPassword(user.Password);
                _accountAccess.CreateUserAccount(user.Username, user.Email, encryptPass.PasswordKey, encryptPass.PasswordSalt);
                return RegisterResult.Succeeded;
            }
            return RegisterResult.EmailExists;
        }

        public async Task<SignInResult> SignIn(string email, string password)
        {
            if (_accountAccess.UserExists(email))
            {
                int id = _accountAccess.GetUserId(email);
                EncryptedPassword pass = _accountAccess.GetEncryptedPassword(id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.NameIdentifier, id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    IsPersistent = true,
                    IssuedUtc = DateTime.Now,
                    RedirectUri = "./Home/Index"
                };

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return SignInResult.Succeeded;
            }
            else
            {
                return SignInResult.EmailIncorrect;
            }
        }

        public async Task SignOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }

    public enum SignInResult
    {
        EmailIncorrect,
        PasswordIncorrect,
        Succeeded
    }

    public enum RegisterResult
    {
        EmailExists,
        Succeeded
    }
}
