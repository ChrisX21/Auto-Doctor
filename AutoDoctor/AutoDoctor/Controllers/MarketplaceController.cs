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
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ApplicationUser _user;

        public MarketplaceController(IOfferRepository offerRepository, IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            _offerRepository = offerRepository;
        }

        public IActionResult All()
        {
            var offers = _offerRepository.GetAllOffers()
                .Select(o => new AllOffersViewModel
                {
                    OfferId = o.Id,
                    Description = o.Description,
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

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
