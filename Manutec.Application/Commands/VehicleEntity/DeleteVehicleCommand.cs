using MediatR;

namespace Manutec.Application.Commands.VehicleEntity;
public class DeleteVehicleCommand : IRequest<Unit>
{
    public DeleteVehicleCommand(int id, int workShopId, int customerId)
    {
        Id = id;
        WorkShopId = workShopId;
        CustomerId = customerId;
    }
    public int Id { get; set; }
    public int WorkShopId { get; set; }
    public int CustomerId { get; set; }
}
