using Manutec.Application.Models;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class UpdateMaintenanceStatusCompletedCommand : IRequest<UpdateCompletedStatusMaintenanceViewModel>
{
    public int WorkShopId {  get; set; }
    public int VehicleId {  get; set; }
    public DateTime ScheduledDate { get; set; }
    public int ScheduledMileage {  get; set; }
}
