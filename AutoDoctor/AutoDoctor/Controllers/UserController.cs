﻿using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
