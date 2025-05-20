using Manutec.Core.Entities;

namespace Manutec.Application.Models.MaintenanceModel;
public class InsertMaintenanceViewModel
{
    public InsertMaintenanceViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

    public static InsertMaintenanceViewModel FromEntity(Maintenance maintenance)
    {
        return new InsertMaintenanceViewModel(maintenance.Id);
    }
}
