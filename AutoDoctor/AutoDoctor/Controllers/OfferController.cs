using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Marketplace;
using AutoDoctor.Web.ViewModels.Part;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        [Authorize(Roles = "Seller, Admin")]
        [ValidateAntiForgeryToken]
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

        [Authorize(Roles = "Seller, Admin")]
        [ValidateAntiForgeryToken]
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

        [Authorize(Roles = "Seller, Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid offerId)
        {
            _offerRepository.DeleteOffer(offerId);
            return RedirectToAction("All", "Marketplace");
        }

        [Authorize(Roles = "Seller, Admin")]
        [ValidateAntiForgeryToken]
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

        [Authorize(Roles = "Seller, Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PartViewModel model, IFormFile ImageFile)
        {
            var part = _partRepository.GetPartById(id);
            if (part == null)
            {
                return NotFound();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                var extension = Path.GetExtension(ImageFile.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                model.ImageUrl = $"/uploads/{uniqueFileName}";
            }

            part.Name = model.Name;
            part.Price = model.Price;
            part.ImageUrl = model.ImageUrl;

            _partRepository.Update(part);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(Guid id)
        {
            var offer = _offerRepository.GetOfferById(id);
            if (offer == null)
            {
                return NotFound();
            }

            offer.Part.Quantity -= 1;

            if (offer.Part.Quantity <= 0)
            {
                _offerRepository.DeleteOffer(id);
            }
            else
            {
                _offerRepository.UpdateOffer(offer);
            }

            return RedirectToAction("All", "Marketplace");
        }
    }
}
