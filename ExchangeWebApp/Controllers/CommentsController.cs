using ExchangeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExchangeWebApp.Controllers
{
    public class CommentsController : Controller
    {
        private string apiUrl = "https://localhost:7134/api/Comments/";
        [BindProperty]
        public CommentDTO CommentDTO { get; set; }
        public static ExchangeResult result = new ExchangeResult();
        public static List<CommentDTO> comment = new List<CommentDTO>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<CommentDTO>> GetAll()
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
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                            comment = JsonConvert.DeserializeObject<List<CommentDTO>>(result.Data.ToString());
                        }
                    }
                }

                return comment;
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
        public async Task<IActionResult> CreateComment()
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                var data = new StringContent(JsonConvert.SerializeObject(CommentDTO), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(apiUrl + "Create", data))
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
            var item = comment.Where(s => s.Id == id).FirstOrDefault();
            return PartialView("Edit", item);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CommentDTO entity)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                var data = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsync(apiUrl + "Update/" + entity.Id, data))
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
        public async Task<IActionResult> Delete(CommentDTO entity)
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
