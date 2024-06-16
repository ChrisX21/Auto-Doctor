using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
