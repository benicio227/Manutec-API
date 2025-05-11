using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetAllMaintenanceHandler : IRequestHandler<GetAllMaintenanceQuery, MaintenancesViewModel>
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public GetAllMaintenanceHandler(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<MaintenancesViewModel> Handle(GetAllMaintenanceQuery request, CancellationToken cancellationToken)
    {
        var maintenances = await _maintenanceRepository.GetAllByWorkShopIdAndVehicleId(request.WorkShopId, request.VehicleId);

        if (maintenances is null)
        {
            throw new Exception("Nenhuma manutenção encontrada");
        }

        var model = MaintenancesViewModel.FromEntity(maintenances);

        return model;
    }
}
