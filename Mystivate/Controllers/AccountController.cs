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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return RedirectToAction("Info", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _signInService.SignIn(model.Email, model.Password);
                
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Info", "Home");
        }

        public IActionResult Register()
        {
            return RedirectToAction("Info", "Home", new { register = true });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInService.SignOut();
            return RedirectToAction("Info", "Home");
        }
    }
}