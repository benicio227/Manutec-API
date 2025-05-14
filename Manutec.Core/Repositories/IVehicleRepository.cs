using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IVehicleRepository
{
    Task<Vehicle> Add(Vehicle vehicle);
    Task<List<Vehicle>> GetAllByWorkShopIdAndCustomerId(int workShopId, int customerId);
    Task<bool> ExistsWithSamePlateInWorkShop(string licensePlate, int workShopId);
    Task<Vehicle?> GetById(int workShopid, int customerId, int id);
    Task<Vehicle?> GetVehicleById(int id);
    Task<Vehicle?> Update(Vehicle vehicle);
    Task<Vehicle?> Delete(Vehicle vehicle);
}
