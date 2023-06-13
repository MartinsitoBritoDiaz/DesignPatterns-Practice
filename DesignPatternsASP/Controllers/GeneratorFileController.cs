using DesignPatterns.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DesignPatternsASP.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _generatorConcreteBuilder = generatorConcreteBuilder ?? throw new ArgumentNullException(nameof(generatorConcreteBuilder));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var beers = _unitOfWork.Beers.GetAll();
                List<string> content = beers.Select(x => x.Name).ToList();
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";
                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);


                if (optionFile == 1)
                    generatorDirector.CreateSimpleJson(content, path);
                else 
                    generatorDirector.CreateSimplePipes(content, path);

                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();

                return Json("File generated");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
