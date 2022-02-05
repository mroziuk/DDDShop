using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApplication.ViewModels;
using Shop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new AccountLoginModel();
            return View(model);
        }
        public async Task<IActionResult> Login(AccountLoginModel model, string returnUrl = "")
        {
            if(this.ModelState.IsValid)
            {
                if(IsValidUser(model.Email, model.Password))
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Email),
                        new Claim(ClaimTypes.Role, model.Email)
                     };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    if(!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ViewBag.Message = "Zła nazwa użytkownika lub hasło";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        private bool IsValidUser(string email, string password)
        {
            var service = new IdentityService();
            return service.isValidUser(email, password);
        }
    }
}
