

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using ExchangeWebApp.Models;
using ExchangeWebApi.DTO;
using Microsoft.IdentityModel.Tokens;

namespace ExchangeWebMVC.Controllers
{
    
    public class SellsController : Controller
    {
        private  string apiUrl = "https://localhost:7134/api/Sell/";

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<SellDTO>> GetAll()
        {
            try
            {
                var sells = new List<SellDTO>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        
                        
                        if (result != null && result.Status > 0 && result.Data != null)
                        {
                            sells = JsonConvert.DeserializeObject<List<SellDTO>>(result.Data.ToString());
                        }
                    }
                }

                return sells;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("create", new SellDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
           
            try
            {
                var API_URL_ENDPOINT = "https://localhost:7134/api/Sell";
                using (var httpClient = new HttpClient()) 
                {
                    using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}/GetById/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var responseSell = JsonConvert.DeserializeObject<ExchangeResult>(content);
                            if (responseSell != null && responseSell.Status > 0 && responseSell.Data != null)
                            {
                                var sellExist = JsonConvert.DeserializeObject<SellDTO>(responseSell.Data.ToString());
                               
                                return PartialView("edit", sellExist);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return PartialView("edit",new SellDTO());
        }
       
        [HttpPost]
        public async Task<ExchangeResult> Create([FromBody] CreateSellDTO sellDTO)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(sellDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(apiUrl + "Create", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<ExchangeResult>(responseContent);
                            return result;
                            
                        }
                        else
                        {
                            throw new Exception(
                                $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
            return null;
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var API_URL_ENDPOINT = "https://localhost:7134/api/Sell" ;

            using (var httpClient = new HttpClient()) 
            {
                using (var response = await httpClient.DeleteAsync($"{API_URL_ENDPOINT}/Delete/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                         var result = JsonConvert.DeserializeObject<ExchangeResult>(content);

                        return Json(new { status = result.Status, message = result.Message });
                    }
                }
            }

            return Json(new { status = -1, message = "Action fail" });
        }
        [HttpPut]
        public async Task<ExchangeResult> Update([FromBody] UpdateSellDTO updateSellRequestDto)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(updateSellRequestDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json"); 
                    using (var response = await httpClient.PutAsync(apiUrl + "Update", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseSell = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<ExchangeResult>(responseSell);
                            return result;
                        }
                        else
                        {
                            throw new Exception(
                                $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<List<SellDTO>> Search([FromForm] string orderCode, string Code , string Price)
        {
            try
            {
                var sells = new List<SellDTO>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ExchangeResult>(content);


                        if (result != null && result.Status > 0 && result.Data != null)
                        {
                            sells = JsonConvert.DeserializeObject<List<SellDTO>>(result.Data.ToString());
                        }
                    }
                }
                var sellExist = new List<SellDTO>();
                if(!orderCode.IsNullOrEmpty())
                {
                    sellExist = sells.Where(p => p.Id == Int32.Parse(orderCode)).ToList();
                }
                if (!Code.IsNullOrEmpty())
                {
                    sellExist= sellExist.Where(p => p.TransactionId == Int32.Parse(Code)).ToList();
                }
                if (!Price.IsNullOrEmpty())
                {
                    sellExist= sellExist.Where(p => p.TotalPrice == Double.Parse(Price)).ToList();
                }
                if (orderCode.IsNullOrEmpty() && Code.IsNullOrEmpty() && Price.IsNullOrEmpty())
                {
                    return sells;
                }
                return sellExist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
