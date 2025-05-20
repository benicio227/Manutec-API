using Manutec.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Manutec.Application.Models.MaintenanceModel;
public class UpcomingMaintenanceViewModel
{
    public UpcomingMaintenanceViewModel(int id, int vehicleId, DateTime sheduledDate, string description)
    {
        Id = id;
        VehicleId = vehicleId;
        SheduledDate = sheduledDate;
        Description = description;
    }

    public int Id {  get; private set; }
    public int VehicleId {  get; private set; }
    public DateTime SheduledDate { get; private set; }
    public string Description {  get; private set; }

    public static List<UpcomingMaintenanceViewModel> FromEntity(List<Maintenance> maintenances)
    {
        return maintenances.Select(maintenance => new UpcomingMaintenanceViewModel(maintenance.Id, maintenance.VehicleId, maintenance.ScheduledDate, maintenance.Description)).ToList();
    }
}
