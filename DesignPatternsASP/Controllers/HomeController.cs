using DesignPatternsASP.Configuration;
using DesignPatternsASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Tools;

namespace DesignPatternsASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> _options;
        public HomeController(IOptions<MyConfig> options)
        {
            _options = options;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_options.Value.PathLog).Save("User went to index");

            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_options.Value.PathLog).Save("User went to privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}