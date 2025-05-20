using Manutec.Application.Models;
using Manutec.Application.Models.VehicleModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.VehicleEntity;
public class InsertVehicleHandler : IRequestHandler<InsertVehicleCommand, ResultViewModel<VehicleViewModel>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public InsertVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResultViewModel<VehicleViewModel>> Handle(InsertVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = request.ToEntity();

        var licensePlateExist = await _vehicleRepository.ExistsWithSamePlateInWorkShop(request.LicensePlate, request.WorkShopId);

        if (licensePlateExist)
        {
            return ResultViewModel<VehicleViewModel>.Error("Já existe um veículo com essa placa registrado nessa oficina.");
        }

        var vehicleExist = await _vehicleRepository.Add(vehicle);

        if (vehicleExist is null)
        {
            return ResultViewModel<VehicleViewModel>.Error("Veículo não cadastrado.");
        }

        var model = VehicleViewModel.FromEntity(vehicleExist);

        return ResultViewModel<VehicleViewModel>.Success(model);
    }
}
