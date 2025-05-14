using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ManutecDbContext _context;

    public UserRepository(ManutecDbContext context)
    {
        _context = context;
    }
    public async Task<User> Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User?> GetById(int workShopId, int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.WorkShopId == workShopId);

        return user;
    }
    public async Task<List<User>> GetAllByWorkShopId(int workShopId)
    {
        var users = await _context.Users.Where(u => u.WorkShopId == workShopId).ToListAsync();
        return users;
    }
    public async Task<User?> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public  async Task<User?> Delete(User user)
    {
        user.Deleted();
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
        return user;
    }
}
