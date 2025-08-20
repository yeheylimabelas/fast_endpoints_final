// -----------------------------------------------------------------------------------
// MSectorJobConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// MSectorJobConfiguration
/// </summary>
public class MSectorJobConfiguration : AuditTableConfiguration<MSector>
{
    /// <summary>
    /// Configure Job
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<MSector> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        builder.HasMany(p => p.MUnitApplications)
            .WithOne(i => i.MSector)
            .HasForeignKey(f => f.SectorId)
            .OnDelete(DeleteBehavior.SetNull);

        base.Configure(builder);
    }
}
