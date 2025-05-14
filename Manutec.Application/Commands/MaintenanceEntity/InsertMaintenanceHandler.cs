using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class InsertMaintenanceHandler : IRequestHandler<InsertMaintenanceCommand, ResultViewModel<MaintenanceViewModel>>
{
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public InsertMaintenanceHandler(IMaintenanceRepository maintenanceRepository, IVehicleRepository vehicleRepository)
    {
        _maintenanceRepository = maintenanceRepository;
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResultViewModel<MaintenanceViewModel>> Handle(InsertMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var maintenance = request.ToEntity();

        var vheicle = await _vehicleRepository.GetVehicleById(request.VehicleId);

        if (vheicle is null)
        {
            return ResultViewModel<MaintenanceViewModel>.Error("Veículo não encontrado.");
        }

        var diff = maintenance.ScheduledMileage - vheicle.CurrentMileage;

        if (diff <= vheicle.ToleranceKm)
        {
            Console.WriteLine($"Manutenção próxima! Diferença: {diff} Km");
        }

        var maintenanceExist = await _maintenanceRepository.Add(maintenance);

        if (maintenanceExist is null)
        {
            return ResultViewModel<MaintenanceViewModel>.Error("Manutenção não cadastrada");
        }



        var model = MaintenanceViewModel.FromEntity(maintenance);

        return ResultViewModel<MaintenanceViewModel>.Success(model);
    }
}
