using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Marketplace;
using AutoDoctor.Web.ViewModels.Part;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPartRepository _partRepository;

        public OfferController(IOfferRepository offerRepository, UserManager<ApplicationUser> userManager, IPartRepository partRepository)
        {
            _offerRepository = offerRepository;
            _userManager = userManager;
            _partRepository = partRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var parts = _partRepository.GetAllParts();
            var model = new OfferDetailsViewModel
            {
                Parts = parts.Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfferDetailsViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var part = _partRepository.GetPartById(model.Part.Id);
            if (part == null)
            {
                return BadRequest("Part not found.");
            }

            var offer = new Offer
            {
                Description = model.Description,
                Views = 0,
                User = user,
                PartId = part.Id,
                Part = part
            };

            await _offerRepository.AddOffer(offer);

            return RedirectToAction("All", "Marketplace");
        }

        public IActionResult Delete(Guid offerId)
        {
            _offerRepository.DeleteOffer(offerId);
            return RedirectToAction("All", "Marketplace");
        }

        [HttpGet]
        public IActionResult Edit(Guid offerId)
        {
            var offer = _offerRepository.GetOfferById(offerId);
            if (offer == null)
            {
                return NotFound();
            }

            var model = new OfferDetailsViewModel
            {
                OfferId = offer.Id,
                Description = offer.Description,
                Part = new PartViewModel
                {
                    Id = offer.Part.Id,
                    Name = offer.Part.Name,
                    ImageUrl = offer.Part.ImageUrl,
                    Price = offer.Part.Price,
                    Manufacturer = offer.Part.User
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid offerId, OfferDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var offer = _offerRepository.GetOfferById(offerId);
            if (offer == null)
            {
                return NotFound();
            }

            offer.Description = model.Description;
            offer.Part.Name = model.Part.Name;
            offer.Part.ImageUrl = model.Part.ImageUrl;
            offer.Part.Price = model.Part.Price;

            _offerRepository.UpdateOffer(offer);

            return RedirectToAction("All", "Marketplace");
        }
    }
}
