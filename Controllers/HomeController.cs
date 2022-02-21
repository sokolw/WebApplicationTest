using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTest.Models;
using Dapper;
using Microsoft.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        private List<User> GetAllUsers()
        {
            using (IDbConnection db = Connection)
            {
                var result = db.Query<User>("SELECT * FROM Users").ToList();
                return result;
            }
        }

        public IActionResult Index()
        {
            var items = GetAllUsers();
            return View(items);
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