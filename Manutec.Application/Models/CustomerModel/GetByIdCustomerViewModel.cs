using Manutec.Core.Entities;

namespace Manutec.Application.Models.CustomerModel;
public class GetByIdCustomerViewModel
{
    public GetByIdCustomerViewModel(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static GetByIdCustomerViewModel FromEntity(Customer customer)
    {
        return new GetByIdCustomerViewModel(customer.Name, customer.Email, customer.Phone);
    }
}
