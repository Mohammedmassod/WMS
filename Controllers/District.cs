﻿using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class District : Controller
    {
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult AddOrEdit()
        {
            return View();
        }
    }
}
