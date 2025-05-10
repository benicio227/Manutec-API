using Manutec.Core.Entities;

namespace Manutec.Application.Models;
public class UpdateCompletedStatusMaintenanceViewModel
{
    public UpdateCompletedStatusMaintenanceViewModel(DateTime? performedDate, int? performedMileage)
    {
        PerformedDate = performedDate;
        PerformedMileage = performedMileage;
    }

    public DateTime? PerformedDate { get; set; }
    public int? PerformedMileage {  set; get; }

    public static UpdateCompletedStatusMaintenanceViewModel FromEntity(Maintenance maintenance)
    {
        return new UpdateCompletedStatusMaintenanceViewModel(maintenance.PerformedDate, maintenance.PerformedMileage);
    }
}
