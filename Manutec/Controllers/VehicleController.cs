using MediatR;
using Manutec.Application.Commands.VehicleEntity;
using Manutec.Application.Queries.VehicleEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Manutec.Infrastructure.Auth;
using Manutec.Application.Models;
using Manutec.Application.Models.VehicleModel;

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

    [ProducesResponseType(typeof(ResultViewModel<VehicleViewModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpPost("register")]
    public async Task<ActionResult> Post(int customerId, InsertVehicleCommand command)
    {
        command.WorkShopId = _loggedUser.WorkShopId;
        command.CustomerId = customerId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { customerId = command.CustomerId, id = result.Data?.Id}, result.Data);
    }

    [ProducesResponseType(typeof(ResultViewModel<List<VehicleViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpGet]
    [Authorize(Roles = "0")]
    public async Task<ActionResult> GetAll(int customerId)
    {

        var query = new GetAllVehicleQuery { WorkShopId = _loggedUser.WorkShopId, CustomerId = customerId };

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [ProducesResponseType(typeof(ResultViewModel<GetByIdVehicleViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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
