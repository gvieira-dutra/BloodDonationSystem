using BloodDonationSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/donor")]
    public class DonorController(IDonor donor) : ControllerBase
    {
        private readonly IDonor _donor = donor;
        [HttpGet]
        public IActionResult GetAll()
        {
            var donor = _donor.GetAll();
            return Ok(donor);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var donor = _donor.GetOne(id);
            return Ok(donor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DonorInputModel newDonor)
        {
            if (newDonor == null)
            {
                return BadRequest();
            }

            var donor = _donor.Post(newDonor);

            return CreatedAtAction(nameof(GetOne), new { id = donor.Id }, donor);
        }
    }
}
