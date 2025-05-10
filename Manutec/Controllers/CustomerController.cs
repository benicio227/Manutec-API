using Manutec.Application.Commands.CustomerEntity;
using Manutec.Application.Queries.CustomerEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers;
[Route("api/workshops/{workShopId}/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int workShopId, InsertCustomerCommand command)
    {
        command.WorkShopId = workShopId;

        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(int workShopId)
    {
        var query = new GetAllCustomerQuery { WorkShopId = workShopId };

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int workShopId, int id)
    {

        var result = await _mediator.Send(new GetByIdCustomerQuery(workShopId, id));

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int workShopId, int id, UpdateCustomerCommand command)
    {
        command.Id = id;
        command.WorkShopId = workShopId;

        var result = await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int workShopId, int id)
    {

        var result = await _mediator.Send(new DeleteCustomerCommand(id, workShopId));

        return NoContent();

    }
}
