using ExchangeBusiness;
using ExchangeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoriesBusiness _categoriesBusiness;
        public CategoryController()
        {
            _categoriesBusiness = new CategoriesBusiness();
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoriesBusiness.GetById(id);
            if (result is null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoriesBusiness.GetAll();
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Category newCategory)
        {
            var result = await _categoriesBusiness.Insert(newCategory);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("UpdateCategoryById/{id}")]
        public async Task<IActionResult> UpdateReport(int id, Category newCategory)
        {
            var result = await _categoriesBusiness.UpdateById(id, newCategory);
            if (result is null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteCategoryById/{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var result = await _categoriesBusiness.RemoveById(id);
            if (result is null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }
    }
}
