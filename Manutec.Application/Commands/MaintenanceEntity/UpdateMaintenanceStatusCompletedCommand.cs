using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class UpdateMaintenanceStatusCompletedCommand : IRequest<ResultViewModel<UpdateCompletedStatusMaintenanceViewModel>>
{
    public int Id { get; set; }
    public int WorkShopId {  get; set; }
    public int VehicleId {  get; set; }
    public DateTime? PerformedDate { get; set; }
    public int? PerformedMileage { get; set; }
}
