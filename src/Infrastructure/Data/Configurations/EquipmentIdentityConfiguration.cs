// -----------------------------------------------------------------------------------
// EquipmentIdentityConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// EquipmentIdentityConfiguration
/// </summary>
public class EquipmentIdentityConfiguration : AuditTableConfiguration<EquipmentIdentity>
{
    /// <summary>
    /// Configure EquipmentIdentity
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<EquipmentIdentity> builder)
    {
        builder.Property(e => e.JobId)
            .HasColumnType("uuid");

        builder.Property(e => e.EquipmentId)
            .HasColumnType("uuid");

        builder.Property(e => e.IsProductUT)
            .HasColumnType("boolean");

        builder.Property(e => e.CustomerOperator)
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

        builder.Property(e => e.IsExcavator)
            .HasColumnType("boolean");

        builder.HasOne(p => p.Equipment).WithMany(i => i.EquipmentValues).HasForeignKey(f => f.EquipmentId).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(p => p.Job).WithMany(i => i.EquipmentIdentities).HasForeignKey(f => f.JobId).OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(b => b.JobId);

        base.Configure(builder);
    }
}
