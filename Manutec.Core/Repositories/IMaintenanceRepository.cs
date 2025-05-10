using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IMaintenanceRepository
{
    Task<Maintenance> Add(Maintenance maintenance);
    Task<List<Maintenance>> GetAllByWorkShopId(int workShopId);

    Task<Maintenance?> GetById(int workShopId, int vehicleId);
    Task<Maintenance?> Complete(int workShopId, int vehicleId);
    Task<Maintenance?> Update(Maintenance maintenance);
}
