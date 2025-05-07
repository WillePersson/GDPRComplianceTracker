using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPRComplianceTracker.Application.Interfaces;
using GDPRComplianceTracker.Domain.Entities;
using GDPRComplianceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GDPRComplianceTracker.Infrastructure.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Company> GetCompanyByOrganizationNumberAsync(string organizationNumber)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(c => c.OrganizationNumber == organizationNumber);
        }
    }
}
