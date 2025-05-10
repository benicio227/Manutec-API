using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Repositories;
public class MaintenanceRepository : IMaintenanceRepository
{
    private readonly ManutecDbContext _context;

    public MaintenanceRepository(ManutecDbContext context)
    {
        _context = context;
    }
    public async Task<Maintenance> Add(Maintenance maintenance)
    {
        await _context.Maintenances.AddAsync(maintenance);
        await _context.SaveChangesAsync();
        return maintenance;
    }

    public async Task<Maintenance?> Complete(int workShopId, int vehicleId)
    {
        var maintenance = await GetById(workShopId, vehicleId);

        return maintenance;
    }

    public async Task<List<Maintenance>> GetAllByWorkShopId(int workShopId)
    {
        throw new NotImplementedException();
    }

    public async Task<Maintenance?> GetById(int workShopId, int vehicleId)
    {
        var maintenance = await _context.Maintenances.FirstOrDefaultAsync(m => m.WorkShopId == workShopId && m.VehicleId == vehicleId);

        return maintenance;
    }

    public async Task<Maintenance?> Update(Maintenance maintenance)
    {
        _context.Maintenances.Update(maintenance);
        await _context.SaveChangesAsync();
        return maintenance;
    }
}
