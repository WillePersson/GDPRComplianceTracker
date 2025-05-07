using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRComplianceTracker.Domain.Entities
{
    public class ExternalPartner
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string PartnerName { get; set; }
        public string PurposeOfSharing { get; set; }
        public string DataShared { get; set; }
        public bool ContractInPlace { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
