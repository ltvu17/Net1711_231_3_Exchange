using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using ExchangeWebApp.Models;

namespace ExchangeWebMVC.Controllers
{
    public class TransactionsController : Controller
    {
        private string apiUrl = "https://localhost:7134/api/Transaction/";

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<TransactionDTO>> GetAll()
        {
            try
            {
                var transactions = new List<TransactionDTO>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        if (result != null && result.Status > 0 && result.Data != null)
                        {
                            transactions = JsonConvert.DeserializeObject<List<TransactionDTO>>(result.Data.ToString());
                        }
                    }
                }

                return transactions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("create", new TransactionDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {

            try
            {
                var API_URL_ENDPOINT = "https://localhost:44362/api/Transaction";
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}/GetById/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var responseTransaction = JsonConvert.DeserializeObject<ExchangeResult>(content);
                            if (responseTransaction != null && responseTransaction.Status > 0 && responseTransaction.Data != null)
                            {
                                var transactionExist = JsonConvert.DeserializeObject<TransactionDTO>(responseTransaction.Data.ToString());
                                return PartialView("edit", transactionExist);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return PartialView("edit", new TransactionDTO());
        }

        [HttpPost]
        public async Task<ExchangeResult> Create([FromBody] TransactionDTO transaction)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(transaction);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(apiUrl + "Create", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<ExchangeResult>(responseContent);
                            var data = JsonConvert.DeserializeObject<TransactionDTO>(result.Data.ToString());
                            result.Data = data;
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
            var API_URL_ENDPOINT = "https://localhost:44362/api/Transaction";

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
        [HttpPost]
        public async Task<List<TransactionDTO>> Search([FromForm] string orderCode)
        {
            try
            {
                var transactions = new List<TransactionDTO>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + "GetAll"))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ExchangeResult>(content);
                        if (result != null && result.Status > 0 && result.Data != null)
                        {
                            transactions = JsonConvert.DeserializeObject<List<TransactionDTO>>(result.Data.ToString());
                        }
                    }
                }

                var transactionsNew = transactions.Where(p => p.Id == Int32.Parse(orderCode)).ToList();
                return transactionsNew;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ExchangeResult> Update([FromBody] TransactionDTO updateTransaction)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(updateTransaction);
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

    }
}
