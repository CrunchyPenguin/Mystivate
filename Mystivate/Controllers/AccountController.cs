using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;
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
        private IRegisterService _registerService;

        public AccountController(ISignInService signInService, IRegisterService registerService)
        {
            _signInService = signInService;
            _registerService = registerService;
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
                Logic.SignInResult result = await _signInService.SignIn(model.Email, model.Password);
                if(result == Logic.SignInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Info", "Home");
                }
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
                RegisterResult result = _registerService.RegisterUser(register);

                switch (result)
                {
                    case RegisterResult.EmailExists:
                        TempData["Message"] = "Email already exists.";
                        return RedirectToAction("Info", "Home", new { register = true });
                    case RegisterResult.UsernameExists:
                        TempData["Message"] = "Username already exists.";
                        return RedirectToAction("Info", "Home", new { register = true });
                    case RegisterResult.PasswordShort:
                        TempData["Message"] = "The password is too short.";
                        return RedirectToAction("Info", "Home", new { register = true });
                    case RegisterResult.UsernameShort:
                        TempData["Message"] = "The username is too short.";
                        return RedirectToAction("Info", "Home", new { register = true });
                    case RegisterResult.Succeeded:
                        return RedirectToAction("Info", "Home");
                    default:
                        return PartialView("_Register", model);
                }
            }
            return PartialView("_Register", model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInService.SignOut();
            return RedirectToAction("Info", "Home");
        }
    }
}