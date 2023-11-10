using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using TestProject.Application.Services;
using TestProject.Common.Enums;
using TestProject.Common.Models;
using TestProject.UI.ViewModels;

namespace TestProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = _accountService.GetByUserName(loginViewModel.Login, loginViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "Пользователь не найден!");
                return View(loginViewModel);
            }

            string roleName = Enum.GetName(typeof(AccountType), user.AccountType);

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(ClaimTypes.Role, roleName)
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(Account user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.AccountType = AccountType.StandardUser;

            var result = _accountService.Register(user);
            if (!result)
            {
                return View();
            }

            string roleName = Enum.GetName(typeof(AccountType), user.AccountType);

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(ClaimTypes.Role, roleName)
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
