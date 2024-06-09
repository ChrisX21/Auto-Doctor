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
            var parts = _partRepository.GetAllPartsAsync();
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

            var part = _partRepository.GetPartByIdAsync(model.Part.Id);
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
    }
}
