using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Marketplace;
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
            IEnumerable<AllOffersViewModel> offers = _offerRepository
                .GetAllOffers()
                .Select(offer => new AllOffersViewModel
                {
                    ImageUrl = offer.ImageUrl,
                    Title = offer.Title,
                    Price = offer.Price,
                    Views = offer.Views,
                    Likes = offer.Likes,
                    User = offer.User
                });

            var model = new OfferIndexViewModel
            {
                AllOffers = offers
            };

            return View(model);
        }
        
        public IActionResult Details(Guid Id)
        {
            
            
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
