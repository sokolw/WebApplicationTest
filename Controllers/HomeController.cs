using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTest.Models;
using Dapper;
using Microsoft.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using WebApplicationTest.Data;

namespace WebApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Users.GetUsers());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Messages()
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