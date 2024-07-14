
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ReportDTO = ExchangeWebApp.Models.ReportDTO;
namespace ExchangeWebApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly string apiUrl = "https://localhost:7134/api/Report/";
        public ReportsController() { }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<ReportDTO>> GetAll()
        {
            try
            {
                var result = new List<ReportDTO>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAllReport"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<ReportDTO>>(content);
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
            return PartialView("Create", new ReportDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportDTO report)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(report);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(apiUrl + "CreateReport", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var createReport = JsonConvert.DeserializeObject<ReportDTO>(responseContent);
                            return Ok(createReport);
                        }
                        else
                        {
                            throw new Exception($"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ReportDTO> Details(int id)
        {
            try
            {
                ReportDTO result = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{apiUrl + "GetReportById"}{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ReportDTO>(content);
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
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var result = new ReportDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{apiUrl + "GetReportById"}/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ReportDTO>(content);
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
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = new ReportDTO();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{apiUrl + "GetReportById"}/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ReportDTO>(content);
                        }
                    }
                }

                return PartialView("edit", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ReportDTO> Update(int id, [FromBody] ReportDTO reportDTO)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(reportDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{apiUrl + "UpdateReportById/"}{id}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var updateReport = JsonConvert.DeserializeObject<ReportDTO>(responseContent);
                            return updateReport;
                        }
                        else
                        {
                            throw new Exception($"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{apiUrl + "DeleteReportById/"}{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
