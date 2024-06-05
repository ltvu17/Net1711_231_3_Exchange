using ExchangeBusiness;
using ExchangeData.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : Controller
    {
        private readonly ExchangeBusiness.ExchangeBusiness _exchangeBusiness;
        public ExchangeController()
        {
            _exchangeBusiness = new ExchangeBusiness.ExchangeBusiness();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _exchangeBusiness.GetAll();
            if(result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _exchangeBusiness.GetById(id);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Exchange entity)
        {
            var result = await _exchangeBusiness.Create(entity);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Exchange entity)
        {
            var result = await _exchangeBusiness.Update(id, entity);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _exchangeBusiness.Remove(id);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
