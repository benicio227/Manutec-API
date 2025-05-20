using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetByIdMaintenanceHandler : IRequestHandler<GetByIdMaintenanceQuery, ResultViewModel<MaintenanceViewModel>>
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public GetByIdMaintenanceHandler(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<ResultViewModel<MaintenanceViewModel>> Handle(GetByIdMaintenanceQuery request, CancellationToken cancellationToken)
    {
        var maintenance = await _maintenanceRepository.GetById(request.MaintenanceId, request.WorkShopId, request.VehicleId);

        if (maintenance is null)
        {
            return ResultViewModel<MaintenanceViewModel>.Error("Nemhuma manutenção encontrada");
        }

        var model = MaintenanceViewModel.FromEntity(maintenance);

        return ResultViewModel<MaintenanceViewModel>.Success(model);
    }
}
