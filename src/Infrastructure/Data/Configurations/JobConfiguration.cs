// -----------------------------------------------------------------------------------
// JobConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// JobConfiguration
/// </summary>
public class JobConfiguration : AuditTableConfiguration<Job>
{
    /// <summary>
    /// Configure Job
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.Property(e => e.CustomerId)
            .HasColumnType("uuid");

        builder.Property(e => e.Number)
            .HasColumnType("varchar(12)")
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.PlantArea)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder.Property(e => e.Latitude)
            .HasColumnType("varchar(30)");

        builder.Property(e => e.Longitude)
            .HasColumnType("varchar(30)");

        builder.Property(e => e.PlanExecutionDate);

        builder.Property(t => t.MainJob)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(e => e.CreatedByName)
            .HasColumnType("varchar(100)");

        builder.Property(e => e.AverageSpeed)
            .HasColumnType("float");

        builder.Property(e => e.LocationDetail)
            .HasColumnType("varchar(50)");

        builder.Property(e => e.JobType)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.HasOne(p => p.Customer)
            .WithMany(i => i.Jobs)
            .HasForeignKey(f => f.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.EquipmentIdentities)
            .WithOne(i => i.Job)
            .HasForeignKey(f => f.JobId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.AdditionalJobs)
            .WithOne(i => i.Job)
            .HasForeignKey(f => f.JobId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.ChecksheetValues)
            .WithOne(i => i.Job)
            .HasForeignKey(f => f.JobId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => new { e.Number }).IsUnique();

        base.Configure(builder);
    }
}
