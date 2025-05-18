using Manutec.Application.Commands.WorkShopEntity;
using Manutec.Application.Models.VehicleModel;
using Manutec.Application.Models;
using Manutec.Application.Queries.WorkShopEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Manutec.Application.Models.WorkShopModel;

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

    [ProducesResponseType(typeof(ResultViewModel<WorkShopViewModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpPost("register")]
    public async Task<ActionResult> Post(InsertWorkShopCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result.Data);
    }

    [ProducesResponseType(typeof(ResultViewModel<WorkShopViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var query = new GetByIdWorkShopQuery { Id = id };

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}
