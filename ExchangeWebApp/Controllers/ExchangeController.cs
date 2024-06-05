using ExchangeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExchangeWebApp.Controllers
{
    public class ExchangeController : Controller
    {
        private string apiUrl = "https://localhost:7134/api/Exchange/";
        [BindProperty]
        public ExchangeDTO ExchangeDTO { get; set; }
        public static List<ExchangeDTO> result = new List<ExchangeDTO>();
        public ExchangeController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<ExchangeDTO>> GetAll()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<ExchangeDTO>>(content);
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
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreateExchange()
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                var data = new StringContent(JsonConvert.SerializeObject(ExchangeDTO), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(apiUrl+"Create", data))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = result.Where(s=>s.Id == id).FirstOrDefault();
            return PartialView("Edit", item);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExchange(ExchangeDTO entity)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                var data = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsync(apiUrl + "Update/"+entity.Id, data))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteExchange(ExchangeDTO entity)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                var data = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + "Delete/" + entity.Id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
