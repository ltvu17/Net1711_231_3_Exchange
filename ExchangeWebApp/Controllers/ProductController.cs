
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ProductDTO = ExchangeWebApp.Models.ProductDTO;

namespace ExchangeWebApp.Controllers
{
    public class ProductController : Controller
    {
        private String apiUrl = "https://localhost:7134/api/Product/";
        public ProductController()
        {

        }
        public IActionResult Index()
        {
            return View("~/Views/Product/Index.cshtml");
        }

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

        public async Task<ProductDTO> CreateProduct(ProductDTO product)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
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
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO product)
        {
            try
            {
                var result = new ProductDTO();
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(product);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(apiUrl + "UpdateProduct", data))
                    {
                        if (response.IsSuccessStatusCode)
                        {
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
