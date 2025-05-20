using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Repositories;
public class WorkShopRepository : IWorkShopRepository
{
    private readonly ManutecDbContext _context;

    public WorkShopRepository(ManutecDbContext context)
    {
        _context = context;
    }
    public async Task<WorkShop> Add(WorkShop workShop)
    {
        await _context.WorkShops.AddAsync(workShop);
        await _context.SaveChangesAsync();
        return workShop;
    }

    public async Task<WorkShop?> EmailExists(string email)
    {
        var workShop = await _context.WorkShops.FirstOrDefaultAsync(w => w.Email == email);
        return workShop;
    }

    public async Task<WorkShop?> GetById(int id)
    {
        var workShop = await _context.WorkShops.FirstOrDefaultAsync(w => w.Id == id);
        return workShop;
    }


}
