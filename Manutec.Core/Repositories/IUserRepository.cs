using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IUserRepository
{
    Task<User> Add(User user);
    Task<List<User>> GetAllByWorkShopId(int workShopId);
    Task<User?> GetById(int workShopid, int id);
    Task<User?> Update(User user);
    Task<User?> Delete(User user);
}
