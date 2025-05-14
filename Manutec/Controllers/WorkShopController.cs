using Manutec.Application.Commands.WorkShopEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkShopController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Post(InsertWorkShopCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Created(string.Empty, result);
    }
}
