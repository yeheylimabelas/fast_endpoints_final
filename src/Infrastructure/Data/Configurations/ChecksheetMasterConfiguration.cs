// -----------------------------------------------------------------------------------
// ChecksheetMasterConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// ChecksheetMasterConfiguration
/// </summary>
public class ChecksheetMasterConfiguration : AuditTableConfiguration<ChecksheetMaster>
{
    /// <summary>
    /// Configure Job
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<ChecksheetMaster> builder)
    {
        builder.Property(t => t.Sector)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(t => t.Parameter)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder.Property(t => t.AssessmentArea)
            .HasMaxLength(250)
            .HasColumnType("varchar(250)");

        builder.Property(t => t.UnitApplication)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder.Property(e => e.UnitApplicationId)
            .HasColumnType("uuid");

        builder.Property(t => t.Klausul)
            .HasMaxLength(5)
            .HasColumnType("varchar(5)");

        builder.Property(t => t.Description)
            .HasMaxLength(250)
            .HasColumnType("varchar(250)");

        builder.Property(t => t.OperationStandard)
            .IsRequired()
            .HasDefaultValue(new string[0])
            .HasColumnType("varchar[]");

        builder.Property(t => t.Guidance)
            .IsRequired()
            .HasDefaultValue(new string[0])
            .HasColumnType("varchar[]");

        builder.Property(t => t.Score)
            .HasColumnType("integer[]");

        builder.Property(t => t.Weight)
            .HasColumnType("real");

        builder.Property(e => e.Sequence)
            .HasColumnType("integer");

        builder.Property(t => t.Measurement)
            .HasMaxLength(5)
            .HasColumnType("varchar(5)");

        builder.HasIndex(e => new { e.Sector, e.Klausul, e.UnitApplication, e.Description }).IsUnique();

        base.Configure(builder);
    }
}
