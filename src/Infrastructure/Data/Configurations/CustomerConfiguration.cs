// -----------------------------------------------------------------------------------
// CustomerConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// CustomerConfiguration
/// </summary>
public class CustomerConfiguration : AuditTableConfiguration<Customer>
{
    /// <summary>
    /// Configure Customer
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(e => e.Code)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.HasMany(p => p.Jobs).WithOne(i => i.Customer).HasForeignKey(f => f.CustomerId).OnDelete(DeleteBehavior.SetNull);

        base.Configure(builder);
    }
}
