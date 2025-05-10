using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class InsertMaintenanceHandler : IRequestHandler<InsertMaintenanceCommand, MaintenanceViewModel>
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public InsertMaintenanceHandler(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<MaintenanceViewModel> Handle(InsertMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var maintenance = request.ToEntity();

        await _maintenanceRepository.Add(maintenance);

        var model = MaintenanceViewModel.FromEntity(maintenance);

        return model;
    }
}
