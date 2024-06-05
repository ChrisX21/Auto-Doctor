using AutoDoctor.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }
        
        [HttpPost]
        public IActionResult New()
        {
            return View();
                        
        }
    }
}
