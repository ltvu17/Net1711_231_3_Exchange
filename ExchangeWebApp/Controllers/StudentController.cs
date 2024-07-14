
using ExchangeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExchangeWebApp.Controllers
{
    public class StudentController : Controller
    {
        private string apiUrl = "https://localhost:7134/api/Student/";

        public StudentController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<OnLoadDTO> GetAll()
        {
            try
            {
                var result = new OnLoadDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAllOnLoad"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<OnLoadDTO>(content);
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
            return PartialView("Create", new Models.StudentDTO());
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteStudents(string id)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + "DeleteStudents?id=" + id)) // Sửa URL để truyền id trên URL
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ExchangeResult>(content);
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

     //   [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                StudentDTO result = new StudentDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetStudent?id=" + id)) // Sửa URL để truyền id trên URL
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<StudentDTO>(content);
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


        [HttpPost]
        public async Task<IActionResult> UpdateStudents(Models.StudentDTO StudentModel)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(StudentModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(apiUrl + "UpdateStudents", content))
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

        [HttpPost]
        public async Task<IActionResult> CreateStudents(StudentDTO StudentModel)
        {
            try
            {
                IExchangeResult result = new ExchangeResult();
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(StudentModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(apiUrl + "CreateStudents", content))
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
        public async Task<IActionResult> GetStudent(string id)
        {
            try
            {
                Models.StudentDTO result = new Models.StudentDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetStudent?id=" + id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<StudentDTO>(content);
                        }
                    }
                }
                return PartialView("Create", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(string Name, string Address, string Phone, string Status)
        {
            try
            {
                List<StudentDTO> studenslist = new List<StudentDTO>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            studenslist = JsonConvert.DeserializeObject<List<StudentDTO>>(content);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(Name))
                {
                    studenslist = studenslist.Where(u => u.Name.Contains(Name, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!string.IsNullOrEmpty(Address))
                {
                    studenslist = studenslist.Where(u => u.Address.Contains(Address, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!string.IsNullOrEmpty(Phone))
                {
                    studenslist = studenslist.Where(u => u.Phone.Contains(Phone)).ToList();
                }
                int statusInput = int.Parse(Status);
                if (!string.IsNullOrEmpty(Status))
                {
                    studenslist = studenslist.Where(u => u.Status == statusInput).ToList();
                }
                var today = DateTime.Now;
                var firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
                var firstDayOfNextMonth = firstDayOfCurrentMonth.AddMonths(1);
                var lastDayOfCurrentMonth = firstDayOfNextMonth.AddDays(-1);
                OnLoadDTO onLoadDTO = new OnLoadDTO()
                {
                    studentList = studenslist,
                    total_user = studenslist.Count(),
                    total_active = studenslist.Count(u => u.Status == 1),
                    total_Inactive = studenslist.Count(u => u.Status == 0),
                    new_user_inmonth = studenslist.Count(u => u.CreatedDate >= firstDayOfCurrentMonth && u.CreatedDate <= lastDayOfCurrentMonth)
                };
                return View("Search", onLoadDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        [HttpPost]
        public async Task<IActionResult> Paging(int pageNumber, string direction)
        {
            try { 
                if (direction == "prev" && pageNumber > 1)
                {
                    pageNumber--;
                }
                else if (direction == "next")
                {
                    pageNumber++;
                }


            List<StudentDTO> students = new List<StudentDTO>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            students = JsonConvert.DeserializeObject<List<StudentDTO>>(content);
                        }
                    }
                }

                int pageSize = 7;
                ViewBag.TotalPages = (int)Math.Ceiling(students.Count() / (double)pageSize);
                List<StudentDTO> paginatedStudents = students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = pageNumber;
                ViewBag.TotalPages = (int)Math.Ceiling(students.Count() / (double)pageSize);

                var today = DateTime.Now;
                var firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
                var firstDayOfNextMonth = firstDayOfCurrentMonth.AddMonths(1);
                var lastDayOfCurrentMonth = firstDayOfNextMonth.AddDays(-1);
                OnLoadDTO onLoadDTO = new OnLoadDTO()
                {
                    studentList = paginatedStudents,
                    total_user = paginatedStudents.Count(),
                    total_active = paginatedStudents.Count(u => u.Status == 1),
                    total_Inactive = paginatedStudents.Count(u => u.Status == 0),
                    new_user_inmonth = paginatedStudents.Count(u => u.CreatedDate >= firstDayOfCurrentMonth && u.CreatedDate <= lastDayOfCurrentMonth)
                };
                return View("Search", onLoadDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
