using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetAllUpcomingHandler : IRequestHandler<GetAllUpcomingMaintenancesQuery, ResultViewModel<List<UpcomingMaintenanceViewModel>>>
{
    private readonly IGeneralMaintenanceRepository _generalMaintenanceRepository;

    public GetAllUpcomingHandler(IGeneralMaintenanceRepository generalMaintenanceRepository)
    {
        _generalMaintenanceRepository = generalMaintenanceRepository;
    }
    public async Task<ResultViewModel<List<UpcomingMaintenanceViewModel>>> Handle(GetAllUpcomingMaintenancesQuery request, CancellationToken cancellationToken)
    {
        var maintenances = await _generalMaintenanceRepository.GetAllUpcomingMaintenance(request.WorkShopId);

        if (!maintenances.Any())
        {
            return ResultViewModel<List<UpcomingMaintenanceViewModel>>.Error("Nehuma mauntenção encontrada para os critérios informados.");
        }

        var model = UpcomingMaintenanceViewModel.FromEntity(maintenances);

        return ResultViewModel<List<UpcomingMaintenanceViewModel>>.Success(model);
    }
}
