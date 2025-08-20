// -----------------------------------------------------------------------------------
// EquipmentConfiguration.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSCoip.Infrastructure.Data.Configurations;

/// <summary>
/// EquipmentConfiguration
/// </summary>
public class EquipmentConfiguration : AuditTableConfiguration<Equipment>
{
    /// <summary>
    /// Configure Equipment
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.Property(e => e.CustomerId)
            .HasColumnType("uuid");

        builder.Property(e => e.UnitModel)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.SerialNumber)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);
        builder.Property(e => e.EquipmentNumber)
            .HasColumnType("varchar(36)")
            .HasMaxLength(36);

        builder.Property(e => e.EquipmentCategory)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder.Property(e => e.UnitCode)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.CustomerCode)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10);

        builder.Property(e => e.CustomerName)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.PlantCode)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10);

        builder.Property(e => e.PlantDescription)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder.Property(e => e.WorkCenterCode)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10);

        builder.Property(e => e.BrandCode)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10);

        builder.Property(e => e.EngineModel)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.EngineSerialNumber)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.MasterWarranty)
            .HasColumnType("varchar(25)")
            .HasMaxLength(25);

        builder.Property(e => e.SMRValuePerDayInMinutes)
            .HasColumnType("double precision");

        builder.Property(e => e.SMRTotalInMinutes)
            .HasColumnType("double precision");

        builder.Property(e => e.CautionCounter)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.KomtraxMeterReading)
            .HasColumnType("double precision");

        builder.Property(e => e.IsProductUT)
            .HasColumnType("boolean");

        builder.Property(e => e.AttachmentModel)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(e => e.AttachmentType)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(e => e.IsAllFleet)
            .HasColumnType("bool")
            .HasDefaultValue(true);

        builder.HasOne(src => src.Customer)
            .WithMany(dst => dst.UnitPopulations)
            .HasForeignKey(fk => fk.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(b => b.EquipmentNumber);
        builder.HasIndex(e => e.SerialNumber);
        builder.HasIndex(e => e.UnitModel);

        base.Configure(builder);
    }
}
