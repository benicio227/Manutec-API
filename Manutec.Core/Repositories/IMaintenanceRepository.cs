using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IMaintenanceRepository
{
    Task<Maintenance> Add(Maintenance maintenance);
    Task<List<Maintenance>> GetAllByWorkShopIdAndVehicleId(int workShopId, int vehicleId);
    Task<Maintenance?> GetById(int id, int workShopId, int vehicleId);
    Task<Maintenance?> Update(Maintenance maintenance);
}
