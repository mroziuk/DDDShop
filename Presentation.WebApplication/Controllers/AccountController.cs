using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApplication.ViewModels;
using Shop.Application;
using Shop.Domain.Model.Customer;
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
        [HttpGet]
        public IActionResult Register()
        {
            var model = new Customer();
            return View(model);
        }
        public async Task<IActionResult> Register(Customer model, string returnUrl = "")
        {
            if(this.ModelState.IsValid)
            {
                model.CreatedAccount = DateTime.Now;
                _identityService.Register(model);
                if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
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
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
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
            return _identityService.isValidUser(email, password);
        }
        private IdentityService _identityService = new IdentityService();
    }
}
