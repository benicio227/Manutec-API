using Manutec.Application.Models;
using Manutec.Core.Entities;
using Manutec.Core.Enums;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class InsertMaintenanceCommand : IRequest<MaintenanceViewModel>
{
    public int VehicleId { get;  set; }
    public int WorkShopId { get; set; }
    public MaintenanceType Type { get; set; }
    public DateTime ScheduledDate { get; set; }
    public int ScheduledMileage { get; set; }
    public DateTime? PerformedDate { get; set; }
    public int? PerformedMileage { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }

    public Maintenance ToEntity()
    {
        return new Maintenance(VehicleId, WorkShopId, Type, ScheduledDate, ScheduledMileage, PerformedDate, PerformedMileage, Cost, Description);
    }
}
