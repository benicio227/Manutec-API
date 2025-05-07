using Manutec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manutec.Infrastructure.Persistence.Configurations;
public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Type).IsRequired();
        builder.Property(m => m.ScheduledDate).IsRequired();
        builder.Property(m => m.ScheduledMileage).IsRequired();
        builder.Property(m => m.Cost).HasColumnType("decimal(10,2)");
        builder.Property(m => m.Description).HasMaxLength(500);
        builder.Property(m => m.IsCompleted).IsRequired();
        builder.Property(m => m.CreatedAt).IsRequired();
    }
}
