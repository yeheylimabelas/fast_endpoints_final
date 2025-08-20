// -----------------------------------------------------------------------------------
// PlantConfiguration.cs 2025
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// PlantConfiguration
/// </summary>
public class PlantConfiguration : AuditTableConfiguration<Plant>
{
    /// <summary>
    /// Configure Job
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.Property(e => e.PlantName)
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.PlantDescription)
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);

        base.Configure(builder);
    }
}
