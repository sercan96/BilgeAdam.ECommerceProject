using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.COREMVC.Models;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System.Diagnostics;

namespace Project.COREMVC.Controllers
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
