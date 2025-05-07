using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPRComplianceTracker.Domain.Entities;

namespace GDPRComplianceTracker.Application.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        // 👇 Example: if you want extra custom queries later
        Task<Company> GetCompanyByOrganizationNumberAsync(string organizationNumber);
    }
}
