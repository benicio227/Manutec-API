using Manutec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manutec.Infrastructure.Persistence.Configurations;
public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Brand).IsRequired().HasMaxLength(50);
        builder.Property(v => v.Model).IsRequired().HasMaxLength(50);
        builder.Property(v => v.Year).IsRequired();
        builder.Property(v => v.LicensePlate).IsRequired().HasMaxLength(20);
        builder.Property(v => v.CurrentMileage).IsRequired();
        builder.Property(v => v.CreatedAt).IsRequired();

        builder.HasIndex(v => new { v.LicensePlate, v.WorkShopId }).IsUnique();

        builder.HasOne(v => v.Customer)
            .WithMany(c => c.Vehicles)
            .HasForeignKey(v => v.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
