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
    public class ExternalPartnerConfiguration : IEntityTypeConfiguration<ExternalPartner>
    {
        public void Configure(EntityTypeBuilder<ExternalPartner> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PartnerName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.PurposeOfSharing)
                .IsRequired();

            builder.Property(p => p.DataShared)
                .IsRequired();

            builder.Property(p => p.ContractInPlace)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .IsRequired();
        }
    }
}
