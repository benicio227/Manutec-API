using Manutec.Application.Models;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetAllMaintenanceQuery : IRequest<MaintenancesViewModel>
{
    public GetAllMaintenanceQuery(int workShopId, int vehicleId)
    {
        WorkShopId = workShopId;
        VehicleId = vehicleId;
    }
    public int WorkShopId {  get; set; }
    public int VehicleId {  get; set; }
}
