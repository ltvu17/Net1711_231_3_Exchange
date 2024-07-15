using ExchangeBusiness;
using ExchangeData;
using ExchangeData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ExchangeWebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductBusiness _business;
        private readonly ICommonService _commonService;
        private readonly UnitOfWork _unitOfWork;
        public ProductController(ICommonService commonService)
        {
            _commonService = commonService;
            _business = new ProductBusiness();
            _unitOfWork = new UnitOfWork();
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _business.GetAll();
            if(result.Status > 0 && result != null) { 
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _business.GetById(id);
            if (result.Status > 0 && result != null)
            {
                var products = result.Data as Product;
                return Ok(products);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = await _business.CreateProduct(product);
            if (result is null || result.Status == -4)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("InactiveProduct")]
        public async Task<IActionResult> InactiveProduct(Product product)
        {
            product.Status = 0;
            var result = await _business.UpdateProduct(product);
            if (result is null || result.Status == -4)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("UploadImg")]
        public async Task<IActionResult> UploadImgProduct(int Id, IFormFile img)
        {
            Product product = await _unitOfWork.ProductRepository.GetByIdAsync(Id);
            if(product != null)
            {
                var imageUrl = await _commonService.UploadAnImage(img, "ProductImg", Id.ToString());
                product.ImgKey = imageUrl;
                var result = await _business.UpdateProduct(product);
                if (result.Status > 0 && result != null)
                {
                    var productR = result.Data as Product;
                    return Ok(productR);
                }
                else
                {
                    return NotFound(result);
                }
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _business.UpdateProduct(product);
            if (result.Status > 0 && result != null)
            {
                var productR = result.Data as Product;
                return Ok(productR);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var result = await _business.DeleteProduct(id);
            switch (result.Status)
            {
                case 400:
                    return BadRequest(result);
                case 404:
                    return NotFound(result);
                case 200:
                    return Ok(result);
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
    }
}
