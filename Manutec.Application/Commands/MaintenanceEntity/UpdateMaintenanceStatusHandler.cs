using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class UpdateMaintenanceStatusHandler : IRequestHandler<UpdateMaintenanceStatusCompletedCommand, ResultViewModel<UpdateCompletedStatusMaintenanceViewModel>>
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public UpdateMaintenanceStatusHandler(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<ResultViewModel<UpdateCompletedStatusMaintenanceViewModel>> Handle(UpdateMaintenanceStatusCompletedCommand request, CancellationToken cancellationToken)
    {
        var maintenance = await _maintenanceRepository.GetById(request.Id, request.WorkShopId, request.VehicleId);

        if (maintenance is null)
        {
            return ResultViewModel<UpdateCompletedStatusMaintenanceViewModel>.Error("Manutenção não encontrada");
        }

        if (maintenance.IsCompleted)
        {
            return ResultViewModel<UpdateCompletedStatusMaintenanceViewModel>.Error("Manutenção já foi concluída.");
        }

        maintenance.Completed(request.PerformedDate, request.PerformedMileage);

        await _maintenanceRepository.Update(maintenance);

        var model = UpdateCompletedStatusMaintenanceViewModel.FromEntity(maintenance);

        return ResultViewModel<UpdateCompletedStatusMaintenanceViewModel>.Success(model);
    }
}
