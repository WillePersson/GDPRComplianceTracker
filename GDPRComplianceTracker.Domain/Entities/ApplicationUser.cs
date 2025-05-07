using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GDPRComplianceTracker.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
