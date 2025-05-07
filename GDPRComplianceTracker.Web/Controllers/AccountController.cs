using GDPRComplianceTracker.Application.DTOs.Account;
using GDPRComplianceTracker.Application.Interfaces;
using GDPRComplianceTracker.Application.Interfaces.IServices;
using GDPRComplianceTracker.Domain.Entities;
using GDPRComplianceTracker.Infrastructure.Data;
using GDPRComplianceTracker.Web.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDPRComplianceTracker.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Auth(bool isRegistering = false)
        {
            ViewBag.IsRegistering = isRegistering;
            var model = new AuthViewModel
            {
                Login = new LoginDto(),
                Register = new RegisterDto()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthViewModel model)
        {
            foreach (var key in ModelState.Keys.Where(k => k.StartsWith("Register.")))
            {
                ModelState.Remove(key);
            }

            if (!ModelState.IsValid)
                return View("Auth", model);

            var (Succeeded, ErrorMessage) = await _accountService.LoginAsync(model.Login);

            if (Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", ErrorMessage);
            return View("Auth", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthViewModel model)
        {
            foreach (var key in ModelState.Keys.Where(k => k.StartsWith("Login.")))
            {
                ModelState.Remove(key);
            }

            if (!ModelState.IsValid)
                return View("Auth", model);

            var (Succeeded, ErrorMessage) = await _accountService.RegisterCompanyAndAdminAsync(model.Register);

            if (Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", ErrorMessage);
            return View("Auth", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Auth");
        }
    }
}
