﻿using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
