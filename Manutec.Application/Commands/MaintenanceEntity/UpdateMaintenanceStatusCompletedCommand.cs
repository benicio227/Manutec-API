using Manutec.Application.Models;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class UpdateMaintenanceStatusCompletedCommand : IRequest<UpdateCompletedStatusMaintenanceViewModel>
{
    public int Id { get; set; }
    public int WorkShopId {  get; set; }
    public int VehicleId {  get; set; }
    public DateTime? PerformedDate { get; set; }
    public int? PerformedMileage { get; set; }
}
