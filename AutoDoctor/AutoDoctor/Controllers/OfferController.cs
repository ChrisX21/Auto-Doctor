using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Marketplace;
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
        public async Task<IActionResult> Create(AllOffersViewModel model)
        {
            if (ModelState.IsValid)
            {
                var offer = new Offer
                {
                    Description = model.Description,
                    User = model.User
                };

                await _offerRepository.AddOffer(offer);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
