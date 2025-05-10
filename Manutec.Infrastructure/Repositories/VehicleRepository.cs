using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Repositories;
public class VehicleRepository : IVehicleRepository
{
    private readonly ManutecDbContext _context;

    public VehicleRepository(ManutecDbContext context)
    {
        _context = context;
    }
    public async Task<Vehicle> Add(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle?> Delete(Vehicle vehicle)
    {
        vehicle.Delete();
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<List<Vehicle>> GetAllByWorkShopId(int workShopId)
    {
        var vehicles = await _context.Vehicles.Where(v => v.WorkShopId == workShopId).ToListAsync();
        return vehicles;
    }

    public async Task<Vehicle?> GetById(int workShopid, int customerId, int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id && v.CustomerId == customerId && v.WorkShopId == workShopid);

        return vehicle;
    }

    public async Task<Vehicle?> Update(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }
}
