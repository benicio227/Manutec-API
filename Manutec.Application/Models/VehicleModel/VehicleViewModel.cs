namespace Manutec.Application.Models.VehicleModel;
public class VehicleViewModel
{
    public VehicleViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
