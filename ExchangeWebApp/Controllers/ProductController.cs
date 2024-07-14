using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ProductDTO = ExchangeWebApp.Models.ProductDTO;

namespace ExchangeWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICommonService _commonService;
        private String apiUrl = "https://localhost:7134/api/Product/";
        public ProductController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Product/Index.cshtml");
        }

        [HttpGet]
        public async Task<List<ProductDTO>> GetAll()
        {
            try
            {
                var result = new List<ProductDTO>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetProducts"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<ProductDTO>>(content);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ProductDTO> GetProductById(string id)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetProduct?id=" +id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductDTO>(content);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetProduct?id=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductDTO>(content);
                        }
                    }
                }

                return PartialView("ProductShowDetail", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> GetProductByUserId()
        {
            try
            {
                var result = new List<ProductDTO>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetProducts"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<ProductDTO>>(content);
                        }
                    }
                }

                return View("~/Views/Product/ProductOfUser.cshtml");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO product, IFormFile img)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    if(img != null)
                    {
                        var imageUrl = await _commonService.UploadAnImage(img, "ProductImg", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                        product.ImgKey = imageUrl;
                    }
                    
                    product.CreateOn = DateTime.Now;
                    product.Status = 1;
                    product.Rate = 0;
                    var json = JsonConvert.SerializeObject(product);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(apiUrl + "CreateProduct", data))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductDTO>(content);
                        }
                    }
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetProduct?id=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductDTO>(content);
                        }
                    }
                }
                return PartialView("Detail", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetProduct?id=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductDTO>(content);
                        }
                    }
                }
                return PartialView("Edit", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> InactiveProduct(string id)
        {
            try
            {
                var result = await GetProductById(id);
                result.Status = 0;
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(result);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(apiUrl + "UpdateProduct", data))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                        }
                    }
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> UpdateProduct(ProductDTO product, IFormFile img)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    if (img != null)
                    {
                        var imageUrl = await _commonService.UploadAnImage(img, "ProductImg", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                        product.ImgKey = imageUrl;
                    }
                    var json = JsonConvert.SerializeObject(product);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(apiUrl + "UpdateProduct", data))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            
                        }
                    }
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductDTO> DeleteProduct(string id)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + "Delete?id=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductDTO>(content);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
