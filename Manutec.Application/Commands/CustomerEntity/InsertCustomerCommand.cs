using Manutec.Application.Models;
using Manutec.Application.Models.CustomerModel;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class InsertCustomerCommand : IRequest<ResultViewModel<CustomerViewModel>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int WorkShopId { get; set; }

    public Customer ToEntity()
    {
        return new Customer(WorkShopId, Name, Email, Phone);
    }
}
