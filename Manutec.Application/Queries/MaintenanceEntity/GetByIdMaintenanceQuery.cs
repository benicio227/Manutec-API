using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetByIdMaintenanceQuery : IRequest<ResultViewModel<MaintenanceViewModel>>
{
    public GetByIdMaintenanceQuery(int vehicleId, int maintenanceId, int workShopId)
    {
        VehicleId = vehicleId;
        MaintenanceId = maintenanceId;
        WorkShopId = workShopId;
    }
    public int VehicleId {  get; set; }
    public int MaintenanceId { get; set; }
    public int WorkShopId {  get; set; }
}
