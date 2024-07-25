using BloodDonationSystem.Application.Query.BloodStockGetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/stock")]
    public class BloodStockController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new BloodStockGetAllQuery();

            var bloodStock = await _mediator.Send(command);
            return Ok(bloodStock);
        }

    }
}
