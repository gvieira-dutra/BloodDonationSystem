using BloodDonationSystem.Application.Command.DonorCreate;
using BloodDonationSystem.Application.Command.DonorDelete;
using BloodDonationSystem.Application.Command.DonorPut;
using BloodDonationSystem.Application.Query.DonorGetAll;
using BloodDonationSystem.Application.Query.DonorGetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/donor")]
    public class DonorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new DonorGetAllQuery();
            var donors = await _mediator.Send(command);

            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var command = new DonorGetOneQuery(id);

            var donor = await _mediator.Send(command);
            return Ok(donor);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DonorPutCommand command)
        {
            var updatedDonor = await _mediator.Send(command);

            return Ok(updatedDonor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DonorCreateCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOne), new { id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DonorDeleteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
