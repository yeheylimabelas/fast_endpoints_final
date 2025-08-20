// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// MobileVersionConfiguration
/// </summary>
public class MobileVersionConfiguration : AuditTableConfiguration<MobileVersion>
{
    /// <summary>
    /// Configure MobileVersion
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<MobileVersion> builder)
    {
        builder.Property(t => t.Version)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(t => t.Environment)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder.Property(e => e.Sequence)
            .HasColumnType("integer");

        builder.HasIndex(b => b.Sequence);

        base.Configure(builder);
    }
}
