using MediatR;
using Manutec.Application.Commands.VehicleEntity;
using Manutec.Application.Queries.VehicleEntity;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers;
[Route("api/workshops/{workShopId}/customers/{customerId}/vehicles")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int workShopId, int customerId, InsertVehicleCommand command)
    {
        command.WorkShopId = workShopId;
        command.CustomerId = customerId;

        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(int workShopId)
    {
        var query = new GetAllVehicleQuery { WorkShopId = workShopId };

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int workShopId, int customerId, int id)
    {

        var result = await _mediator.Send(new GetByIdVehicleQuery(id, customerId, workShopId));

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int workShopId, int customerId, int id, UpdateVehicleCommand command)
    {
        command.Id = id;
        command.WorkShopId = workShopId;
        command.CustomerId = customerId;

        var result = await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int workShopId, int customerId, int id)
    {
        var result = await _mediator.Send(new DeleteVehicleCommand(id, workShopId, customerId));

        return NoContent();
    }
}
