using System.Diagnostics;
using GDPRComplianceTracker.Application.Interfaces;
using GDPRComplianceTracker.Domain.Entities;
using GDPRComplianceTracker.Web.Models;
using GDPRComplianceTracker.Web.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDPRComplianceTracker.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICompanyRepository _companyRepository;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ICompanyRepository companyRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Auth", "Account");

            ViewData["ShowHome"] = false; 
            ViewData["Breadcrumbs"] = new List<(string, string?)>
            {
                ("Home", null)
            };


            var company = await _companyRepository.GetByIdAsync(user.CompanyId);

            var model = new HomeViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CompanyName = company?.CompanyName,
                OrganizationNumber = company?.OrganizationNumber
            };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
