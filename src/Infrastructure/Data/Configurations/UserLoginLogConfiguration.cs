// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// UserLoginLogConfiguration
/// </summary>
public class UserLoginLogConfiguration : AuditTableConfiguration<UserLoginLog>
{
    /// <summary>
    /// Configure UserLoginLog
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<UserLoginLog> builder)
    {
        builder.Property(e => e.UserName)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(e => e.IsMobileDevice)
            .HasColumnType("boolean");

        base.Configure(builder);
    }
}
