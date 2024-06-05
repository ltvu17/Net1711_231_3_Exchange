using ExchangeBusiness;
using ExchangeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportBusiness _reportBusiness;
        public ReportController()
        {
            _reportBusiness = new ReportBusiness();
        }

        [HttpGet("GetReportById/{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            var result = await _reportBusiness.GetById(id);
            if (result is null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }
        [HttpGet("GetAllReport")]
        public async Task<IActionResult> GetAllReport()
        {
            var result = await _reportBusiness.GetAll();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport(Report newReport)
        {
            var result = await _reportBusiness.Insert(newReport);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("UpdateReportById/{id}")]
        public async Task<IActionResult> UpdateReport(int id, Report request)
        {
            var result = await _reportBusiness.UpdateById(id, request);
            if (result is null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteReportById/{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var result = await _reportBusiness.RemoveById(id);
            if (result is null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }
    }
}
