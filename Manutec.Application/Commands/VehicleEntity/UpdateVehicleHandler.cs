using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.VehicleEntity;
public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, ResultViewModel>
{
    private readonly IVehicleRepository _vehicleRepository;

    public UpdateVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResultViewModel> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = request.ToEntity();

        var vehicleExist = await _vehicleRepository.GetById(request.WorkShopId, request.CustomerId, request.Id);

        if (vehicleExist is null)
        {
            return ResultViewModel.Error("Veículo não encontrado");
        }

        vehicleExist.UpdateYear(request.Year);
        vehicleExist.UpdateBrand(request.Brand);
        vehicleExist.UpdateCurrentMileage(request.CurrentMileage);

        await _vehicleRepository.Update(vehicleExist);

        return ResultViewModel.Success();
    }
}
