using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
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
        private readonly IRepository<Beer> _repository;
        public HomeController(IOptions<MyConfig> options, IRepository<Beer> repository)
        {
            _options = options;
            _repository = repository;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_options.Value.PathLog).Save("User went to index");
            IEnumerable<Beer> beers = _repository.GetAll();

            return View("Index", beers);
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