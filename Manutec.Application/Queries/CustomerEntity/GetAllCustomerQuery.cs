using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.CustomerEntity;
public class GetAllCustomerQuery : IRequest<List<Customer>>
{
    public int WorkShopId {  get; set; }
}
