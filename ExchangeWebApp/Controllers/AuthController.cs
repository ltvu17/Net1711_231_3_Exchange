using ExchangeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExchangeWebApp.Controllers
{
    public class AuthController : Controller
    {
        private string apiUrl = "https://localhost:7134/api/User/";

        public AuthController()
        {
            
        }
        [BindProperty]
        public UserDTO UserDTO { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
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
                var userList = JsonConvert.DeserializeObject<List<UserDTO>>(result.Data.ToString());
                var user = userList.Where(s => s.Name == UserDTO.Name && s.Password == UserDTO.Password).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserId",user.Id);
                    HttpContext.Session.SetString("Role", user.Role);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
