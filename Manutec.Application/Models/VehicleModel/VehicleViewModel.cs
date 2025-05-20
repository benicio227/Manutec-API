using Manutec.Core.Entities;

namespace Manutec.Application.Models.VehicleModel;
public class VehicleViewModel
{
    public VehicleViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

    public static VehicleViewModel FromEntity(Vehicle vehicle)
    {
        return new VehicleViewModel(vehicle.Id);
    }
}
