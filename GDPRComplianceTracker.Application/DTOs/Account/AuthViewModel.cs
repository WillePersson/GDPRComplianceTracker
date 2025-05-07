using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRComplianceTracker.Application.DTOs.Account
{
    public class AuthViewModel
    {
        public LoginDto Login { get; set; } = new LoginDto();
        public RegisterDto Register { get; set; } = new RegisterDto();
    }
}
