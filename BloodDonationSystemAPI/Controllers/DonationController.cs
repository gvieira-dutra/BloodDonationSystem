using BloodDonationSystem.Application.Interfaces;
using BloodDonationSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/donation")]
    public class DonationController(IDonation donation) : ControllerBase
    {
        private readonly IDonation _donation = donation;

        [HttpPost]
        public IActionResult Post([FromBody] DonationInputModel newDonation)
        {
            if (newDonation == null)
            {
                return BadRequest();
            }

            _donation.CreateOne(newDonation);

            return Ok(newDonation);

        }

        [HttpGet("recent")]
        public IActionResult GetRecent()
        {
            var donations = _donation.GetRecent();

            return Ok(donations);
        }

    }
}
