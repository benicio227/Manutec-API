using Manutec.Application.Models;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class DeleteCustomerCommand : IRequest<ResultViewModel>
{
    public DeleteCustomerCommand(int id, int workShopId)
    {
        Id = id;
        WorkShopId = workShopId;
    }
    public int Id { get; set; }
    public int WorkShopId { get; set; }
}
