using BloodDonationSystem.Application.Command.DonationCreate;
using BloodDonationSystem.Application.Query.DonationGetRecent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/donation")]
    public class DonationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DonationCreateCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return Ok(command);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecent()
        {
            var command = new DonationGetRecentQuery();

            var donations = await _mediator.Send(command);

            return Ok(donations);
        }

    }
}
