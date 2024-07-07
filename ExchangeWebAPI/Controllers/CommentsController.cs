using ExchangeData.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {

        private readonly ExchangeBusiness.CommentsBusiness _commentsBusiness;
        public CommentsController()
        {
            _commentsBusiness = new ExchangeBusiness.CommentsBusiness();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentsBusiness.GetAll();
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _commentsBusiness.GetById(id);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Comment entity)
        {
            var result = await _commentsBusiness.Create(entity);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Comment entity)
        {
            var result = await _commentsBusiness.Update(id, entity);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _commentsBusiness.Remove(id);
            if (result.Status == -1)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
