using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetAllMaintenanceHandler : IRequestHandler<GetAllMaintenanceQuery, ResultViewModel<MaintenancesViewModel>>
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public GetAllMaintenanceHandler(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<ResultViewModel<MaintenancesViewModel>> Handle(GetAllMaintenanceQuery request, CancellationToken cancellationToken)
    {
        var maintenances = await _maintenanceRepository.GetAllByWorkShopIdAndVehicleId(request.WorkShopId, request.VehicleId);

        if (maintenances is null)
        {
            return ResultViewModel<MaintenancesViewModel>.Error("Nenhuma manutenção encontrada");
        }

        var model = MaintenancesViewModel.FromEntity(maintenances);

        return ResultViewModel<MaintenancesViewModel>.Success(model);
    }
}
