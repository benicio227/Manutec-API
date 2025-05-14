using Manutec.Application.Models;
using Manutec.Application.Models.VehicleModel;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetByIdVehicleQuery : IRequest<ResultViewModel<GetByIdVehicleViewModel>>
{
    public GetByIdVehicleQuery(int id, int customerId, int workShopId)
    {
        Id = id;
        CustomerId = customerId;
        WorkShopId = workShopId;
    }
    public int Id { get; set; }
    public int CustomerId {  get; set; }
    public int WorkShopId {  get; set; }
}
