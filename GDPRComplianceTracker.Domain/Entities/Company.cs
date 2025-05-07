using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRComplianceTracker.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string Address { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<DataActivity> DataActivities { get; set; }
        public ICollection<SystemStorage> Systems { get; set; }
        public ICollection<ExternalPartner> ExternalPartners { get; set; }
    }
}
