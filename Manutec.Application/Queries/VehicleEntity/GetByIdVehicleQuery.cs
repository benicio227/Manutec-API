using Manutec.Application.Models;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetByIdVehicleQuery : IRequest<VehicleViewModel>
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
