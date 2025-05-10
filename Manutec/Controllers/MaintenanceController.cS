using Manutec.Application.Commands.MaintenanceEntity;
using Manutec.Application.Commands.VehicleEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers;
[Route("api/workshops/{workShopId}/vehicles/{vehicleId}/maintenances")]
[ApiController]
public class MaintenanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> Post(int workShopId, int vehicleId, InsertMaintenanceCommand command)
    {
        command.WorkShopId = workShopId;
        command.VehicleId = vehicleId;

        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

    [HttpPatch]
    public async Task<ActionResult> Complete(int workShopId, int vehicleId, UpdateMaintenanceStatusCompletedCommand command)
    {
        command.WorkShopId = workShopId;
        command.VehicleId = vehicleId;

        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

}
