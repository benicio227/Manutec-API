using Manutec.Application.Models;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetAllVehicleQuery : IRequest<ResultViewModel<List<Vehicle>>>
{
    public int WorkShopId {  get; set; }
    public int CustomerId {  get; set; }
}
