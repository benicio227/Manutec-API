using Manutec.Application.Models;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetAllVehicleHandler : IRequestHandler<GetAllVehicleQuery, ResultViewModel<List<Vehicle>>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetAllVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResultViewModel<List<Vehicle>>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetAllByWorkShopIdAndCustomerId(request.WorkShopId, request.CustomerId);

        if (vehicles is null)
        {
            return ResultViewModel<List<Vehicle>>.Error("Nenhum veículo encontrado");
        }

        return ResultViewModel<List<Vehicle>>.Success(vehicles);
    }
}
