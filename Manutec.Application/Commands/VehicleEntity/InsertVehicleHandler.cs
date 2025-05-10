using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.VehicleEntity;
public class InsertVehicleHandler : IRequestHandler<InsertVehicleCommand, VehicleViewModel>
{
    private readonly IVehicleRepository _vehicleRepository;

    public InsertVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<VehicleViewModel> Handle(InsertVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = request.ToEntity();

        var vehicleExist = await _vehicleRepository.Add(vehicle);

        var model = VehicleViewModel.FromEntity(vehicle);

        return model;
    }
}
