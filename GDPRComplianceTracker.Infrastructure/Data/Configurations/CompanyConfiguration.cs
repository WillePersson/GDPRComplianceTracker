using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPRComplianceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GDPRComplianceTracker.Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.OrganizationNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Address)
                .HasMaxLength(300);

            builder.Property(c => c.ContactPersonName)
                .HasMaxLength(100);

            builder.Property(c => c.ContactPersonEmail)
                .HasMaxLength(100);

            builder.HasMany(c => c.Users)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId);

            builder.HasMany(c => c.DataActivities)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.CompanyId);

            builder.HasMany(c => c.Systems)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId);

            builder.HasMany(c => c.ExternalPartners)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId);
        }
    }
}
