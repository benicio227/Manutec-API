using Manutec.Application.Models;
using Manutec.Application.Models.CustomerModel;
using MediatR;

namespace Manutec.Application.Queries.CustomerEntity;
public class GetByIdCustomerQuery : IRequest<ResultViewModel<CustomerViewModel>>
{
    public GetByIdCustomerQuery(int workShopId, int id)
    {
        Id = id;
        WorkShopId = workShopId;
    }
    public int Id { get; set; }
    public int WorkShopId {  get; set; }
}
