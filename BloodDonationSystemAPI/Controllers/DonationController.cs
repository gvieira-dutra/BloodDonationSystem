using BloodDonationSystem.Application.Command.DonationCreate;
using BloodDonationSystem.Application.Command.DonationDelete;
using BloodDonationSystem.Application.Command.DonationPut;
using BloodDonationSystem.Application.Query.DonationGetRecent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/donation")]
    public class DonationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecent()
        {
            var command = new DonationGetRecentQuery();

            var donations = await _mediator.Send(command);

            return Ok(donations);
        }

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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DonationPutCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return Ok(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DonationDeleteCommand(id);
            await _mediator.Send(command);    

            return NoContent();
        }
    }
}
