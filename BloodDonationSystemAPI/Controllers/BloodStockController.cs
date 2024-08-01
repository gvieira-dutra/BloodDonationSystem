using BloodDonationSystem.Application.Command.BookStockPut;
using BloodDonationSystem.Application.Query.BloodStockGetAll;
using BloodDonationSystem.Core.DTO;
using BloodDonationSystem.Infrastructure.Configurations.Service;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BloodDonationSystemAPI.Controllers
{
    [Route("api/stock")]
    public class BloodStockController(IMediator mediator, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new BloodStockGetAllQuery();

            var bloodStock = await _mediator.Send(command);
            return Ok(bloodStock);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BloodStockPutCommand command)
        {
            var bloodStock = await _mediator.Send(command);

            return Ok(bloodStock);
        }

        [Route("pdfReport")]
        [HttpGet]
        public async Task<ActionResult<List<BloodStockDTO>>> GetReportPDF()
        {
            var command = new BloodStockGetAllQuery();
            var bloodStock = await _mediator.Send(command);

            if(bloodStock == null) { return NotFound(); }

            var webReport = new WebReport();

            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/Report", "BloodStockReportTemplate.frx"));

            GenerateDataTableReport(bloodStock, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();

            webReport.Report.Export(new PDFSimpleExport(), stream);

            stream.Flush();
            byte[] arrayReport = stream.ToArray();

            return File(arrayReport, "application/zip", "BloodStockReport.pdf");

        }

        private void GenerateDataTableReport(List<BloodStockDTO> bloodStock, WebReport webReport)
        {
            var bloodStockDataTable = new DataTable();

            bloodStockDataTable.Columns.Add("BloodType", typeof(string));
            bloodStockDataTable.Columns.Add("RhFactor", typeof(string));
            bloodStockDataTable.Columns.Add("Quantity", typeof(int));

            foreach (var item in bloodStock)
            {
                bloodStockDataTable.Rows.Add(item.BloodType, item.RhFactor, item.Quantity);
            }
            webReport.Report.RegisterData(bloodStockDataTable, "Stock Report");
        }
    }
}
