using Manutec.Core.Entities;

namespace Manutec.Core.Repositories;
public interface ICustomerRepository
{
    Task<Customer> Add(Customer customer);
    Task<List<Customer>> GetAllByWorkShopId(int workShopId);
    Task<Customer?> GetById(int workShopid, int id);
    Task<Customer?> Update(Customer customer);
    Task<Customer?> Delete(Customer customer);
}
