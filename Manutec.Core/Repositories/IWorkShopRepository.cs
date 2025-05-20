using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IWorkShopRepository
{
    Task<WorkShop> Add(WorkShop workShop);
    Task<WorkShop?> GetById(int id);
    Task<WorkShop?> EmailExists(string email);
}
