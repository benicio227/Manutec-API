using Manutec.Core.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Manutec.Application.Models.MaintenanceModel;
public class MaintenancesViewModel
{
    public MaintenancesViewModel(List<Maintenance> maintenances)
    {
        Maintenances = maintenances;
    }

    public List<Maintenance> Maintenances { get; set; }

    public static MaintenancesViewModel FromEntity(List<Maintenance> maintenances)
    {
        return new MaintenancesViewModel(maintenances);
    }
}
