using Manutec.Application.Commands.UserEntity;
using Manutec.Application.Queries.UserEntity;
using Manutec.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Manutec.Api.Controllers;
[ApiController]
[Route("api/users")]


public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILoggedUser _loggedUser;

    public UserController(IMediator mediator, ILoggedUser loggedUser)
    {
        _mediator = mediator;
        _loggedUser = loggedUser;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Post(InsertUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new {id = result.Data?.Id}, result.Data);
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var query = new GetAllUserQuery { WorkShopId = _loggedUser.WorkShopId };

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetByIdUserQuery(_loggedUser.WorkShopId, id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, UpdateUserCommand command)
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

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id, _loggedUser.WorkShopId));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}
