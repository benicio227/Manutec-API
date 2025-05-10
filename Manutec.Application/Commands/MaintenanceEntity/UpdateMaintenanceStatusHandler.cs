using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class UpdateMaintenanceStatusHandler : IRequestHandler<UpdateMaintenanceStatusCompletedCommand, UpdateCompletedStatusMaintenanceViewModel>
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public UpdateMaintenanceStatusHandler(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<UpdateCompletedStatusMaintenanceViewModel> Handle(UpdateMaintenanceStatusCompletedCommand request, CancellationToken cancellationToken)
    {
        var maintenance = await _maintenanceRepository.GetById(request.WorkShopId, request.VehicleId);

        if (maintenance is null)
        {
            throw new Exception("Manutenção não encontrada");
        }

        maintenance.UpdateScheduledDate(request.ScheduledDate);
        maintenance.UpdateScheduledMileage(request.ScheduledMileage);
        maintenance.Completed();

        await _maintenanceRepository.Update(maintenance);

        var model = UpdateCompletedStatusMaintenanceViewModel.FromEntity(maintenance);

        return model;
    }
}
