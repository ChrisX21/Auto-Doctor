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
                    User = o.User,
                    Part = new PartViewModel
                    {
                        Id = o.Part.Id,
                        Name = o.Part.Name,
                        ImageUrl = o.Part.ImageUrl,
                        Price = o.Part.Price,
                        Manufacturer = o.Part.User
                    }
                })
                .ToList();

            return View(offers);
        }

        public ActionResult Details(Guid Id)
        {
            var offer = _offerRepository.GetOfferById(Id);
            offer.Views += 1;
            _offerRepository.UpdateOffer(offer);

            var detailedOffer = new OfferDetailsViewModel
            {
                OfferId = offer.Id,
                Description = offer.Description,
                Views = offer.Views,
                Manufacturer = offer.User,
                Part = new PartViewModel
                {
                    Id = offer.Part.Id,
                    Name = offer.Part.Name,
                    ImageUrl = offer.Part.ImageUrl,
                    Price = offer.Part.Price,
                    Manufacturer = offer.User
                }
            };

            return View(detailedOffer);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
