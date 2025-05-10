using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetAllVehicleQuery : IRequest<List<Vehicle>>
{
    public int WorkShopId {  get; set; }
}
