using Manutec.Application.Queries.MaintenanceEntity;
using Manutec.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.Controllers
{
    [Route("api/maintenances")]
    [ApiController]
    public class GeneralMaintenanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggedUser _loggedUser;
        public GeneralMaintenanceController(IMediator mediator, ILoggedUser loggedUser)
        {
            _mediator = mediator;
            _loggedUser = loggedUser;
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult> GetAllUpcoming(GetAllUpcomingMaintenancesQuery query)
        {
            query.WorkShopId = _loggedUser.WorkShopId;

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
