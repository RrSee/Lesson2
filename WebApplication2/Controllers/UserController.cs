using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly string jsonFilePath = "Helpers/User.json";
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new UserAddViewModel()
            {
                User = new User(),
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{ Text="Baku" , Value="1"},
                    new SelectListItem { Text = "Gence" ,Value = "2"},
                    new SelectListItem { Text = "Sumqayit" ,Value = "3"},
                    new SelectListItem { Text = "Agdam" ,Value = "4"}
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(UserAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userData = new
                {
                    id = viewModel.User.Id,
                    firstName = viewModel.User.FirstName,
                    lastName = viewModel.User.LastName,
                    cityId = viewModel.User.CityId
                };

                var jsonData = JsonSerializer.Serialize(userData, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.AppendAllText(jsonFilePath, jsonData);

                return RedirectToAction("jsonData");
            }

            return View(viewModel);
        }

        public JsonResult jsonDataa()
        {
			if (System.IO.File.Exists(jsonFilePath))
			{
				var jsonData = System.IO.File.ReadAllText(jsonFilePath);
                return Json(jsonData);
			}

			return Json("error");
		}

        //public ViewResult jsonData()
        //{
        //    var userList = new List<User>();
        //    if (System.IO.File.Exists(jsonFilePath))
        //    {
        //        var jsonData = System.IO.File.ReadAllText(jsonFilePath);
        //        userList = JsonSerializer.Deserialize<List<User>>(jsonData);
        //    }

        //    return View(userList);
        //}

    }
}
