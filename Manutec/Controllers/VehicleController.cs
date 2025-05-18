using MediatR;
using Manutec.Application.Commands.VehicleEntity;
using Manutec.Application.Queries.VehicleEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Manutec.Infrastructure.Auth;

namespace Manutec.Api.Controllers;
[Route("api/customers/{customerId}/vehicles")]
[ApiController]

public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILoggedUser _loggedUser;
    public VehicleController(IMediator mediator, ILoggedUser loggedUser)
    {
        _mediator = mediator;
        _loggedUser = loggedUser;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int customerId, InsertVehicleCommand command)
    {
        command.WorkShopId = _loggedUser.WorkShopId;
        command.CustomerId = customerId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id}, result.Data);
    }

    [HttpGet]
    [Authorize(Roles = "1")]
    public async Task<ActionResult> Get(int customerId)
    {

        var query = new GetAllVehicleQuery { WorkShopId = _loggedUser.WorkShopId, CustomerId = customerId };

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult> GetById(int customerId, int id)
    {

        var result = await _mediator.Send(new GetByIdVehicleQuery(id, customerId, _loggedUser.WorkShopId));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int customerId, int id, UpdateVehicleCommand command)
    {
        command.Id = id;
        command.WorkShopId = _loggedUser.WorkShopId;
        command.CustomerId = customerId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int customerId, int id)
    {
        var result = await _mediator.Send(new DeleteVehicleCommand{
            Id = id,
            CustomerId = customerId,
            WorkShopId = _loggedUser.WorkShopId
        });

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}
