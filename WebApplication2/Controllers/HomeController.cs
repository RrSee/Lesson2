using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebApplication2.Controllers
{
	public class HomeController : Controller
	{
        private readonly string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers", "User.json");

        public IActionResult Index()
		{
			return View();
		}
	}
}
