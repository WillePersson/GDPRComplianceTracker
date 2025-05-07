using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRComplianceTracker.Domain.Entities
{
    public class SystemStorage
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string SystemName { get; set; }
        public string StorageLocation { get; set; }
        public string Description { get; set; }
        public string SecurityLevel { get; set; } // Example values: Low, Medium, High
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
