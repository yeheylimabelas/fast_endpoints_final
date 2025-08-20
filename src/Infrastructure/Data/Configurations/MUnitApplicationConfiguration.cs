// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// MUnitApplicationConfiguration
/// </summary>
public class MUnitApplicationConfiguration : AuditTableConfiguration<MUnitApplication>
{
    /// <summary>
    /// Configure MUnitApplication
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<MUnitApplication> builder)
    {
        builder.Property(e => e.SectorId)
            .HasColumnType("uuid");

        builder.Property(e => e.Name)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(p => p.MSector)
            .WithMany(i => i.MUnitApplications)
            .HasForeignKey(f => f.SectorId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.MasterChecksheetCustomers)
            .WithOne(i => i.MUnitApplication)
            .HasForeignKey(f => f.UnitApplicationId)
            .OnDelete(DeleteBehavior.SetNull);

        base.Configure(builder);
    }
}
