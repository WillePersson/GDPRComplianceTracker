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
    public class SystemStorageConfiguration : IEntityTypeConfiguration<SystemStorage>
    {
        public void Configure(EntityTypeBuilder<SystemStorage> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SystemName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.StorageLocation)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.Property(s => s.SecurityLevel)
                .HasMaxLength(50);

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.Property(s => s.UpdatedAt)
                .IsRequired();
        }
    }
}
