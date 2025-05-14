using Manutec.Application.Models;
using Manutec.Application.Models.VehicleModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.VehicleEntity;
public class GetByIdVehicleHandler : IRequestHandler<GetByIdVehicleQuery, ResultViewModel<GetByIdVehicleViewModel>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetByIdVehicleHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResultViewModel<GetByIdVehicleViewModel>> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetById(request.WorkShopId, request.CustomerId, request.Id);

        if (vehicle is null)
        {
            return ResultViewModel<GetByIdVehicleViewModel>.Error("Nenhum veículo encontrado");
        }

        var model = GetByIdVehicleViewModel.FromEntity(vehicle);

        return ResultViewModel<GetByIdVehicleViewModel>.Success(model);
    }
}
