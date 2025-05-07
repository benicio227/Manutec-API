using Manutec.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Persistence;
public class ManutecDbContext : DbContext
{
    public ManutecDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<User> Users {  get; set; }
    public DbSet<Customer> Customers {  get; set; }
    public DbSet<Vehicle> Vehicles {  get; set; }
    public DbSet<WorkShop> WorkShops {  get; set; }
    public DbSet<Maintenance> Maintenances {  get; set; }


    protected override void OnModelCreating(ModelBuilder model)
    {
        model.ApplyConfigurationsFromAssembly(typeof(ManutecDbContext).Assembly);

        base.OnModelCreating(model);
    }
}
