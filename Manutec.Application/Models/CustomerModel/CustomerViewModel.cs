using Manutec.Core.Entities;

namespace Manutec.Application.Models.CustomerModel;
public class CustomerViewModel
{
    public CustomerViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }

    public static CustomerViewModel FromEntity(Customer customer)
    {
        return new CustomerViewModel(customer.Id);
    }
}
