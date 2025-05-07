using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPRComplianceTracker.Application.DTOs.Account;

namespace GDPRComplianceTracker.Application.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<(bool Succeeded, string ErrorMessage)> RegisterCompanyAndAdminAsync(RegisterDto model);
        Task<(bool Succeeded, string ErrorMessage)> LoginAsync(LoginDto model);
        Task LogoutAsync();
    }
}
