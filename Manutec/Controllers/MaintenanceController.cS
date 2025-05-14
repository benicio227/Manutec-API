using Manutec.Application.Commands.MaintenanceEntity;
using Manutec.Application.Commands.VehicleEntity;
using Manutec.Application.Queries.MaintenanceEntity;
using Manutec.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Manutec.Api.Controllers;
[Route("api/vehicles/{vehicleId}/maintenances")]
[ApiController]
public class MaintenanceController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILoggedUser _loggedUser;

    public MaintenanceController(IMediator mediator, ILoggedUser loggedUser)
    {
        _mediator = mediator;
        _loggedUser = loggedUser;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int vehicleId, InsertMaintenanceCommand command)
    {
        command.WorkShopId = _loggedUser.WorkShopId;
        command.VehicleId = vehicleId;

        var result = await _mediator.Send(command);

        if (result is null)
        {
            return BadRequest(result.Message);
        }

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(int vehicleId)
    {
        var result = await _mediator.Send(new GetAllMaintenanceQuery(_loggedUser.WorkShopId, vehicleId));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpPatch("{id}")]
    public async Task<ActionResult> Complete(int id, int vehicleId, UpdateMaintenanceStatusCompletedCommand command)
    {
        command.WorkShopId = _loggedUser.WorkShopId;
        command.VehicleId = vehicleId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
        {
            return BadRequest(result.Message);
        }

        return Created(string.Empty, result);
    }

}
