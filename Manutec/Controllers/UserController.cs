using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post()
    {
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put()
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete()
    {
        return NoContent();
    }
}
