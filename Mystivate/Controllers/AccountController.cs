using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Code.Logic;
using Mystivate.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Mystivate.Controllers
{
    public class AccountController : Controller
    {
        private ISignInService _signInService;
        public AccountController(ISignInService signInService)
        {
            _signInService = signInService;
        }

        //[Authorize]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Login()
        {
            return RedirectToAction("Info", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Code.Logic.SignInResult result = await _signInService.SignIn(model.Email, model.Password);
                
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Info", "Home");
        }

        public IActionResult Register()
        {
            return RedirectToAction("Info", "Home", new { register = true });
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                RegisterModel register = new RegisterModel
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password
                };
                RegisterResult result = _signInService.RegisterUser(register);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Info", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInService.SignOut();
            return RedirectToAction("Info", "Home");
        }
    }
}