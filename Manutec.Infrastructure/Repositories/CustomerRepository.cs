using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Manutec.Infrastructure.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly ManutecDbContext _context;

    public CustomerRepository(ManutecDbContext context)
    {
        _context = context;
    }
    public async Task<Customer> Add(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> Delete(Customer customer)
    {
        customer.Delete();
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<List<Customer>> GetAllByWorkShopId(int workShopId)
    {
        var customers = await _context.Customers.Where(u => u.WorkShopId == workShopId).ToListAsync();
        return customers;
    }

    public async Task<Customer?> GetById(int workShopid, int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(u => u.Id == id && u.WorkShopId == workShopid);

        return customer;
    }

    public async Task<Customer?> Update(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
}
