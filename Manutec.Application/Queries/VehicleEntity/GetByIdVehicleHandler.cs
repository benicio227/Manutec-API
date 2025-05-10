using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetByIdVehicleHandler : IRequestHandler<GetByIdVehicleQuery, VehicleViewModel>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetByIdVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<VehicleViewModel> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetById(request.WorkShopId, request.CustomerId, request.Id);

        if (vehicle is null)
        {
            throw new Exception("Nenhum veículo encontrado");
        }

        var model = VehicleViewModel.FromEntity(vehicle);

        return model;
    }
}
