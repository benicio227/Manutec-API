using Manutec.Application.Models;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class UpdateCustomerCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public int WorkShopId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Customer ToEntity()
    {
        return new Customer(WorkShopId, Name, Email, Phone);
    }
}
