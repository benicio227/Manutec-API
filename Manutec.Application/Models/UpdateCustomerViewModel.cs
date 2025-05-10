using Manutec.Core.Entities;

namespace Manutec.Application.Models;
public class UpdateCustomerViewModel
{
    public UpdateCustomerViewModel(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static UpdateCustomerViewModel FromEntity(Customer customer)
    {
        return new UpdateCustomerViewModel(customer.Name, customer.Email, customer.Phone);
    }
}
