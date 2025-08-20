// -----------------------------------------------------------------------------------
// AdditionalJobConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// AdditionalJobConfiguration
/// </summary>
public class AdditionalJobConfiguration : AuditTableConfiguration<AdditionalJob>
{
    /// <summary>
    /// Configure Job
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<AdditionalJob> builder)
    {
        builder.Property(e => e.JobId)
            .HasColumnType("uuid");

        builder.Property(e => e.Desc)
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Parameter)
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.UnitApplication)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(p => p.Job).WithMany(i => i.AdditionalJobs).HasForeignKey(f => f.JobId).OnDelete(DeleteBehavior.SetNull);

        base.Configure(builder);
    }
}
