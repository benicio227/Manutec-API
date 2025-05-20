using Manutec.Core.Entities;

namespace Manutec.Core.Repositories
{
    public interface IGeneralMaintenanceRepository
    {
        Task<List<Maintenance?>> GetAllUpcomingMaintenance(int workShopId);
    }
}
