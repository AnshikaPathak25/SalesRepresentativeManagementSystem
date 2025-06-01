using BusinessLayer.IService;
using BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalesRepManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SalesRepController : ControllerBase
    {
        private readonly ISalesRepBL _salesRepBL;
        private readonly ILogger<SalesRepController> _logger;

        public SalesRepController(ISalesRepBL salesRepBL, ILogger<SalesRepController> logger)
        {
            _salesRepBL = salesRepBL;
            _logger = logger;
        }

        [HttpGet("get")]
        [Authorize]
        public ActionResult GetSalesReps()
        {
            var salesRepList = _salesRepBL.GetAllSaleReps();
            _logger.LogInformation("Processing sales representative data...");

            return StatusCode(StatusCodes.Status200OK, salesRepList);
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public ActionResult GetSalesRep(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid SalesRep ID. ID must be a positive number.");
            

            var salesRep = _salesRepBL.GetSaleRepById(id);

            if (salesRep == null)
                return StatusCode(StatusCodes.Status404NotFound, $"Sales Representative with ID {id} not found.");

            return StatusCode(StatusCodes.Status200OK, salesRep);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddSalesRep(SalesRepresentativeModel salesRep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isadded = _salesRepBL.AddSalesRep(salesRep);

            if (isadded)
                return StatusCode(StatusCodes.Status201Created, isadded);
            else
                return StatusCode(StatusCodes.Status400BadRequest, isadded);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateSalesRep(SalesRepresentativeModel salesRep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isupdated = _salesRepBL.UpdateSalesRep(salesRep);

            if (isupdated)
                return StatusCode(StatusCodes.Status200OK, isupdated);
            else
                return StatusCode(StatusCodes.Status400BadRequest, isupdated);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSalesRep(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid SalesRep ID. ID must be a positive number.");

            var isdeletd = _salesRepBL.RemoveSalesRep(id);

            if (isdeletd)
                return StatusCode(StatusCodes.Status200OK, "Details of sales representative has been deleted.");
            else
                return StatusCode(StatusCodes.Status204NoContent, isdeletd);
        }

    }
}
