using Manutec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manutec.Infrastructure.Persistence.Configurations;
public class WorkShopConfiguration : IEntityTypeConfiguration<WorkShop>
{
    public void Configure(EntityTypeBuilder<WorkShop> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name).IsRequired().HasMaxLength(100);
        builder.Property(w => w.Email).IsRequired().HasMaxLength(100);
        builder.Property(w => w.Phone).HasMaxLength(20);
        builder.Property(w => w.CreatedAt).IsRequired();

        builder.HasMany(w => w.Users)
            .WithOne(u => u.WorkShop)
            .HasForeignKey(u => u.WorkShopId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.Customers)
            .WithOne(c => c.WorkShop)
            .HasForeignKey(c => c.WorkShopId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.Maintenances)
            .WithOne(m => m.WorkShop)
            .HasForeignKey(m => m.WorkShopId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.Vehicles)
            .WithOne(v => v.WorkShop)
            .HasForeignKey(v => v.WorkShopId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
