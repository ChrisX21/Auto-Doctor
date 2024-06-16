using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
