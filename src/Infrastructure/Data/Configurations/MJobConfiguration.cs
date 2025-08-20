// -----------------------------------------------------------------------------------
// MJobConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// MJobConfiguration
/// </summary>
public class MJobConfiguration : AuditTableConfiguration<MJob>
{
    /// <summary>
    /// Configure MJob
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<MJob> builder)
    {
        builder.Property(e => e.JobType)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.Desc)
            .HasColumnType("varchar(50)")

            .HasMaxLength(50);

        builder.Property(e => e.ParentId)
            .HasColumnType("uuid");

        builder.Property(e => e.Sequence)
            .HasColumnType("serial");

        builder.Property(e => e.IsParent)
            .HasColumnType("boolean");

        builder.HasIndex(b => b.Sequence);

        base.Configure(builder);
    }
}
