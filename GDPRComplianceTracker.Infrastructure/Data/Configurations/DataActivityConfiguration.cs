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
    public class DataActivityConfiguration : IEntityTypeConfiguration<DataActivity>
    {
        public void Configure(EntityTypeBuilder<DataActivity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.ActivityName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.Purpose)
                .IsRequired();

            builder.Property(d => d.LegalBasis)
                .IsRequired();

            builder.Property(d => d.DataCategories)
                .IsRequired();

            builder.Property(d => d.RetentionPeriod)
                .IsRequired();

            builder.Property(d => d.SecurityMeasures)
                .IsRequired();

            builder.Property(d => d.CreatedAt)
                .IsRequired();

            builder.Property(d => d.UpdatedAt)
                .IsRequired();
        }
    }
}
