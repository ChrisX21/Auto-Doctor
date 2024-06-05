using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Marketplace;
using AutoDoctor.Web.ViewModels.Part;
using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class MarketplaceController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        public MarketplaceController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IActionResult All()
        {
            var offers = _offerRepository.GetAllOffers()
                .Select(o => new AllOffersViewModel
                {
                    OfferId = o.Id,
                    Description = o.Description,
                    Part = new PartViewModel
                    {
                        Id = o.Part.Id,
                        Name = o.Part.Name,
                        ImageUrl = o.Part.ImageUrl,
                        Price = o.Part.Price,
                        User = o.Part.User
                    }
                })
                .ToList();

            return View(offers);
        }

        public ActionResult Details(Guid Id)
        {
            var offer = _offerRepository.GetOfferById(Id);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
