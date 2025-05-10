using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.VehicleEntity;
public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, Unit>
{
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetById(request.WorkShopId, request.CustomerId, request.Id);

        if (vehicle == null)
        {
            throw new Exception("Nehum veículo encontrado");
        }

        await _vehicleRepository.Delete(vehicle);

        return Unit.Value;
    }
}
