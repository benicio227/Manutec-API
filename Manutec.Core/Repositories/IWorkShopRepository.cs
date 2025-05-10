using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IWorkShopRepository
{
    Task<WorkShop> Add(WorkShop workShop);
}
