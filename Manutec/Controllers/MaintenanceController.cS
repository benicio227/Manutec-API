using Manutec.Application.Commands.MaintenanceEntity;
using Manutec.Application.Commands.VehicleEntity;
using Manutec.Application.Queries.MaintenanceEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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

    [HttpPost]
    public async Task<ActionResult> Post(int workShopId, int vehicleId, InsertMaintenanceCommand command)
    {
        command.WorkShopId = workShopId;
        command.VehicleId = vehicleId;

        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(int workShopId, int vehicleId)
    {
        var result = await _mediator.Send(new GetAllMaintenanceQuery(workShopId, vehicleId));

        return Ok(result);
    }


    [HttpPatch("{id}")]
    public async Task<ActionResult> Complete(int id, int workShopId, int vehicleId, UpdateMaintenanceStatusCompletedCommand command)
    {
        command.WorkShopId = workShopId;
        command.VehicleId = vehicleId;


        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

}
