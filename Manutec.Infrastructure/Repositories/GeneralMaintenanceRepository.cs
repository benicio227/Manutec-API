using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Repositories;
public class GeneralMaintenanceRepository : IGeneralMaintenanceRepository
{
    private readonly ManutecDbContext _context;

    public GeneralMaintenanceRepository(ManutecDbContext context)
    {
        _context = context;
    }
    public async Task<List<Maintenance?>> GetAllUpcomingMaintenance(int workShopId)
    {
        var today = DateTime.Now;
        var nextFiveDays = today.AddDays(5);

        var maintenances = await _context.Maintenances
            .Where(m => m.ScheduledDate >= today &&
                m.ScheduledDate <= nextFiveDays && !m.IsCompleted && m.WorkShopId == workShopId)
            .ToListAsync();

        return maintenances;
    }
}
