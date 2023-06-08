using DesignPatternsASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tools;

namespace DesignPatternsASP.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger)
        {
        }

        public IActionResult Index()
        {
            Log.GetInstance("log.txt").Save("User went to index");

            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance("log.txt").Save("User went to privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}