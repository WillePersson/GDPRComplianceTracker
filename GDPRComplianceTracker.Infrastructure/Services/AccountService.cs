using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPRComplianceTracker.Application.Interfaces.IServices;
using GDPRComplianceTracker.Application.Interfaces;
using GDPRComplianceTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using GDPRComplianceTracker.Application.DTOs.Account;

namespace GDPRComplianceTracker.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ICompanyRepository _companyRepository;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            ICompanyRepository companyRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _companyRepository = companyRepository;
        }

        public async Task<(bool Succeeded, string ErrorMessage)> RegisterCompanyAndAdminAsync(RegisterDto model)
        {
            var company = new Company
            {
                Id = Guid.NewGuid(),
                CompanyName = model.CompanyName,
                OrganizationNumber = model.OrganizationNumber,
                Address = model.Address,
                ContactPersonName = $"{model.FirstName} {model.LastName}",
                ContactPersonEmail = model.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _companyRepository.AddAsync(company);

            var user = new ApplicationUser
            {
                CompanyId = company.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, errors);
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
            }

            await _userManager.AddToRoleAsync(user, "Admin");
            await _signInManager.SignInAsync(user, isPersistent: false);

            return (true, null);
        }

        public async Task<(bool Succeeded, string ErrorMessage)> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return (false, "Invalid login attempt.");

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
                return (true, null);

            return (false, "Invalid login attempt.");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
