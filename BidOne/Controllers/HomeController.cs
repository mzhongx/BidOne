using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BidOne.Models;
using System.Text.Json;


namespace BidOne.Controllers
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

        public IActionResult SaveNames(NameModel model)
        {

            if (model != null) {
                if (!string.IsNullOrEmpty(model.Firstname) && !string.IsNullOrEmpty(model.Lastname))
                {
                    //save to Json
                    try
                    {
                        string filename = "NameData.json";
                        string jsonString = JsonSerializer.Serialize(model);
                        System.IO.File.AppendAllText(filename, jsonString);
                        ViewData["SavingResult"] = "successful";
                    }
                    catch
                    {
                        ViewData["SavingResult"] = "fail";
                    }
                }
                else
                {
                    ViewData["SavingResult"] = "full name needed";
                }
            }
            else
            {
                ViewData["SavingResult"] = "something went wrong";
            }


           


            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
