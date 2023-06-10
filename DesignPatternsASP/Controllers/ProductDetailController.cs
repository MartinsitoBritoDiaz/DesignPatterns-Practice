using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternsASP.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //Factories
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.15m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.35m, 50);

            //Products
            IEarn localEarn = localEarnFactory.GetEarn();
            IEarn foreignEarn = foreignEarnFactory.GetEarn();

            ViewBag.totalLocal = total + localEarn.Earn(350);
            ViewBag.totalForeign = total + foreignEarn.Earn(350);
            return View();
        }
    }
}
