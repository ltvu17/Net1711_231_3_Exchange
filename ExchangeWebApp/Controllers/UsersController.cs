using Microsoft.AspNetCore.Mvc;
using ExchangeWebApp.Models;
using Newtonsoft.Json;
using UserDTO = ExchangeWebApp.Models.UserDTO;
using System.Text;

namespace ExchangeWebApp.Controllers
{
    public class UsersController : Controller
    {
        private string apiUrl = "https://localhost:7134/api/User/";

        public UsersController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAll()
        {
            try
            {
                var result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        }
                    }
                }

                return JsonConvert.DeserializeObject<List<UserDTO>>(result.Data.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("Create", new UserDTO());
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(string id)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + "DeleteUsers?id=" + id)) // Sửa URL để truyền id trên URL
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        }
                    }
                }

                return View ("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> UpdateUsers(UserDTO userModel)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(userModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(apiUrl + "UpdateUsers", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(responseContent);
                        }
                    }
                }

                return View ("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateUsers( UserDTO userModel)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(userModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(apiUrl + "CreateUsers", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(responseContent);
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
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetUser?id=" +id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        }
                    }
                }
                return PartialView("Create", JsonConvert.DeserializeObject<UserDTO>(result.Data.ToString()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
