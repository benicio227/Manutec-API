using Manutec.Application.Commands.CustomerEntity;
using Manutec.Application.Models.VehicleModel;
using Manutec.Application.Models;
using Manutec.Application.Queries.CustomerEntity;
using Manutec.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Manutec.Application.Models.CustomerModel;

namespace Manutec.Api.Controllers;
[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILoggedUser _loggedUser;

    public CustomerController(IMediator mediator, ILoggedUser loggedUser)
    {
        _mediator = mediator;
        _loggedUser = loggedUser;
    }

    [ProducesResponseType(typeof(ResultViewModel<CustomerViewModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpPost("register")]
    public async Task<ActionResult> Post(InsertCustomerCommand command)
    {
        command.WorkShopId = _loggedUser.WorkShopId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id}, result.Data);
    }

    [ProducesResponseType(typeof(ResultViewModel<List<CustomerViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var query = new GetAllCustomerQuery { WorkShopId = _loggedUser.WorkShopId};

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [ProducesResponseType(typeof(ResultViewModel<CustomerViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {

        var result = await _mediator.Send(new GetByIdCustomerQuery(_loggedUser.WorkShopId, id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, UpdateCustomerCommand command)
    {
        command.Id = id;
        command.WorkShopId = _loggedUser.WorkShopId;

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
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCustomerCommand(id, _loggedUser.WorkShopId));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();

    }
}
