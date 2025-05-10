using Manutec.Core.Entities;
using Manutec.Core.Enums;

namespace Manutec.Application.Models;
public class MaintenanceViewModel
{
    public MaintenanceViewModel(int id, int vehicleId, int workShopId, MaintenanceType type,
        DateTime scheduledDate, int scheduledMileage, DateTime? performedDate, int? perfomedMileage, decimal cost, string description)
    {
        Id = id;
        VehicleId = vehicleId;
        WorkShopId = workShopId;
        Type = type;
        ScheduledDate = scheduledDate;
        ScheduledMileage = scheduledMileage;
        PerformedDate = performedDate;
        PerformedMileage = PerformedMileage;
        Cost = cost;
        Description = description;
    }

    public int Id { get; private set; }
    public int VehicleId { get; private set; }
    public int WorkShopId { get; private set; }
    public MaintenanceType Type { get; private set; }
    public DateTime ScheduledDate { get; private set; }
    public int ScheduledMileage { get; private set; }
    public DateTime? PerformedDate { get; private set; }
    public int? PerformedMileage { get; private set; }
    public decimal Cost { get; private set; }
    public string Description { get; private set; }

    public static MaintenanceViewModel FromEntity(Maintenance maintenance)
    {
        return new MaintenanceViewModel(maintenance.Id, maintenance.VehicleId, maintenance.WorkShopId,
            maintenance.Type, maintenance.ScheduledDate, maintenance.ScheduledMileage,
            maintenance.PerformedDate, maintenance.PerformedMileage, maintenance.Cost, maintenance.Description);
    }

}
