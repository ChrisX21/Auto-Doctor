using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class MarketplaceController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
