using ExchangeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExchangeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View("~/Views/Home/UserProfile.cshtml");
        }
        public IActionResult TransactionOfUser()
        {
            return View("~/Views/Transactions/TransactionOfUser.cshtml");
        }
        public IActionResult ProductOfUser()
        {
            return View("~/Views/Product/ProductOfUser.cshtml");
        }
        public IActionResult ProductOfUserToExchange()
        {
            return View("~/Views/Product/ProductOfUserToExchange.cshtml");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}