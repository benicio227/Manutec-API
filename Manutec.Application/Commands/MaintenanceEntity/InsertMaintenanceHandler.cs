using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.MaintenanceEntity;
public class InsertMaintenanceHandler : IRequestHandler<InsertMaintenanceCommand, ResultViewModel<InsertMaintenanceViewModel>>
{
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public InsertMaintenanceHandler(IMaintenanceRepository maintenanceRepository, IVehicleRepository vehicleRepository)
    {
        _maintenanceRepository = maintenanceRepository;
        _vehicleRepository = vehicleRepository;
    }
    public async Task<ResultViewModel<InsertMaintenanceViewModel>> Handle(InsertMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var maintenance = request.ToEntity();

        var vheicle = await _vehicleRepository.GetVehicleById(request.VehicleId);

        if (vheicle is null)
        {
            return ResultViewModel<InsertMaintenanceViewModel>.Error("Veículo não encontrado.");
        }

        var diff = maintenance.ScheduledMileage - vheicle.CurrentMileage;

        if (diff <= vheicle.ToleranceKm)
        {
            Console.WriteLine($"Manutenção próxima! Diferença: {diff} Km");
        }

        var maintenanceExist = await _maintenanceRepository.Add(maintenance);

        if (maintenanceExist is null)
        {
            return ResultViewModel<InsertMaintenanceViewModel>.Error("Manutenção não cadastrada");
        }


        var model = InsertMaintenanceViewModel.FromEntity(maintenanceExist);

        return ResultViewModel<InsertMaintenanceViewModel>.Success(model);
    }
}
