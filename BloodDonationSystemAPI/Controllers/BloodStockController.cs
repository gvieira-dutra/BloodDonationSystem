using BloodDonationSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/stock")]
    public class BloodStockController(IBloodStock bloodStock) : ControllerBase
    {
        private readonly IBloodStock _bloodStock = bloodStock;

        [HttpGet]
        public IActionResult GetAll()
        {
            var bloodStock = _bloodStock.GetAll();
            return Ok(bloodStock);
        }

    }
}
