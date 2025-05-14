using Manutec.Application.Commands.UserEntity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginUserController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginUserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}
