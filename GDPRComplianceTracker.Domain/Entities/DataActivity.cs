using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRComplianceTracker.Domain.Entities
{
    public class DataActivity
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string ActivityName { get; set; }
        public string Purpose { get; set; }
        public string LegalBasis { get; set; }
        public string DataCategories { get; set; }
        public string RetentionPeriod { get; set; }
        public string SecurityMeasures { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
