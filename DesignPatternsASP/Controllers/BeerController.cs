using DesignPatterns.Models.Data;
using DesignPatterns.Repository.UnitOfWork;
using DesignPatternsASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPatternsASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.GetAll()
                                                select new BeerViewModel
                                                {
                                                    BeerId = d.BeerId,
                                                    Name = d.Name,
                                                    Style = d.Style,
                                                };
                                                
            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _unitOfWork.Brands.GetAll();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            if (!ModelState.IsValid)
            {
                var brands = _unitOfWork.Brands.GetAll();
                ViewBag.Brands = new SelectList(brands, "BrandId", "Name");

                return View("Add", beerVM);
            }

            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            if(beerVM.BrandId == null)
            {
                var brand = new Brand();
                brand.Name = beerVM.OtherBrand;
                brand.BrandId = Guid.NewGuid();
                beer.BrandId = brand.BrandId;
                _unitOfWork.Brands.Add(brand);                
            }else
            {
                beer.BrandId = (Guid)beerVM.BrandId;
            }

            _unitOfWork.Beers.Add(beer);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
