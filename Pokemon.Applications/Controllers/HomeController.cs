using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Applications.Models;
using Pokemon.Models.Entities;
using Pokemon.Repository.Repositories;

namespace Pokemon.Applications.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            using (var rep = new PlayerRepository())
            {
                ViewBag.QtdOnline = rep.ListarQtdOnline();
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(Contact model)
        {
            using (var repository = new ContactRepository())
            {
                repository.Insert(model);

                repository.SaveAll();

                return Redirect("/Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
