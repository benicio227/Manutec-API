using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface IUserRepository
{
    Task<User> Add(User user);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> Update(User user);
    Task<User> Delete(int id);
}
