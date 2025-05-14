using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetAllMaintenanceQuery : IRequest<ResultViewModel<MaintenancesViewModel>>
{
    public GetAllMaintenanceQuery(int workShopId, int vehicleId)
    {
        WorkShopId = workShopId;
        VehicleId = vehicleId;
    }
    public int WorkShopId {  get; set; }
    public int VehicleId {  get; set; }
}
