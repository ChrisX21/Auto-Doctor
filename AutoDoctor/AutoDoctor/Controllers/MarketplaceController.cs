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
                    Description = offer.Description,
                    Price = offer.Price,
                    User = offer.User
                });

            var model = new OfferIndexViewModel
            {
                AllOffers = offers
            };

            return View(model);
        }
        
        public IActionResult Details()
        {
            //OfferDetailsViewModel model = new OfferDetailsViewModel
            //{
            //    ImageUrl = "https://via.placeholder.com/150",
            //    Title = "Offer Title",
            //    Description = "Offer Description",
            //    Price = 100,
            //    Vehicle = new VehicleViewModel
            //    {
            //        Make = "Make",
            //        Model = "Model",
            //        Year = 2020
            //    }
            //};
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
