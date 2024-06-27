using ExchangeBusiness;
using ExchangeData.Models;
using Microsoft.AspNetCore.Mvc;
using Firebase.Storage;


namespace ExchangeWebAPI.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ProductBusiness _business;
        public ProductController(IWebHostEnvironment env)
        {
            _business = new ProductBusiness();
            _env = env;
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
        [Route("UploadProduct")]
        public async Task OnPostAsync(IFormFile photo)
        {
            string basePath = "https://exchange-products-a33d6-default-rtdb.firebaseio.com/";
            string authSecret = "YXwxp8JigbbNNXqdXGn2jDNpE2ZJwnt4Olz1Hyrj";
            IFirebaseClient

            var path = Path.Combine(_env.ContentRootPath, "Uploads", photo.FileName);
            var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream);

            // Tên tệp
            var fileName = photo.FileName;

            // Tải lên Firebase Storage
            var task = await new FirebaseStorage("exchange-products-a33d6.appspot.com", new FirebaseStorageOptions
            {
                ThrowOnCancel = true
            })
            .Child("image-product")
            .Child($"IMAGE_{Guid.NewGuid()}{Path.GetExtension(fileName)}")
            .PutAsync(stream);

            stream.Close();
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
