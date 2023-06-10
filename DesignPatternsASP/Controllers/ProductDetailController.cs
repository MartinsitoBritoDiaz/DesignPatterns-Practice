using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternsASP.Controllers
{
    public class ProductDetailController : Controller
    {
        LocalEarnFactory _localEarnFactory;
        ForeignEarnFactory _foreignEarnFactory;
        public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignEarnFactory = foreignEarnFactory;
        }

        public IActionResult Index(decimal total)
        {

            //Products
            IEarn localEarn = _localEarnFactory.GetEarn();
            IEarn foreignEarn = _foreignEarnFactory.GetEarn();

            ViewBag.totalLocal = total + localEarn.Earn(350);
            ViewBag.totalForeign = total + foreignEarn.Earn(350);
            return View();
        }
    }
}
