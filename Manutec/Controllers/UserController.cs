using Manutec.Application.Commands.UserEntity;
using Manutec.Application.Queries.UserEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Manutec.Api.Controllers;
[Route("api/workshops/{workShopId}/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int workShopId, InsertUserCommand command)
    {
        command.WorkShopId = workShopId;

        var result = await _mediator.Send(command);

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<ActionResult> Get(int workShopId)
    {
        var query = new GetAllUserQuery { WorkShopId = workShopId };

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int workShopId, int id)
    {

        var result = await _mediator.Send(new GetByIdUserQuery(workShopId, id));

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int workShopId, int id, UpdateUserCommand command)
    {
        command.Id = id;
        command.WorkShopId = workShopId;

        var result = await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int workShopId, int id)
    {

        var result = await _mediator.Send(new DeleteUserCommand(id, workShopId));

        return NoContent();
    }
}
