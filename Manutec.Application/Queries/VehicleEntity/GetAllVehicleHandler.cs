using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetAllVehicleHandler : IRequestHandler<GetAllVehicleQuery, List<Vehicle>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetAllVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<List<Vehicle>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetAllByWorkShopId(request.WorkShopId);

        return vehicles;
    }
}
