// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// MasterChecksheetCustomerConfiguration
/// </summary>
public class MasterChecksheetCustomerConfiguration : AuditTableConfiguration<MasterChecksheetCustomer>
{
    /// <summary>
    /// Configure MasterChecksheetCustomer
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<MasterChecksheetCustomer> builder)
    {
        builder.Property(e => e.UnitApplicationId)
            .HasColumnType("uuid");

        builder.Property(e => e.CustomerCode)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.HasOne(p => p.MUnitApplication)
            .WithMany(i => i.MasterChecksheetCustomers)
            .HasForeignKey(f => f.UnitApplicationId)
            .OnDelete(DeleteBehavior.SetNull);

        base.Configure(builder);
    }
}
