using Manutec.Core.Entities;

namespace Manutec.Application.Models.CustomerModel;
public class CustomerViewModel
{
    public CustomerViewModel(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static CustomerViewModel FromEntity(Customer customer)
    {
        return new CustomerViewModel(customer.Name, customer.Email, customer.Phone);
    }
}
