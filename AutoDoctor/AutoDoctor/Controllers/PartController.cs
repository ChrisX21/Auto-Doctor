﻿using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Part;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AutoDoctor.Controllers
{
    public class PartController : Controller
    {
        private readonly IPartRepository _partRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PartController(IPartRepository partRepository, UserManager<ApplicationUser> userManager)
        {
            _partRepository = partRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var parts = _partRepository.GetAllParts().Select(part => new PartViewModel
            {
                Id = part.Id,
                Name = part.Name,
                ImageUrl = part.ImageUrl,
                Price = part.Price,
                Quantity = part.Quantity,
                Manufacturer = part.User
            }).ToList();

            return View(parts);
        }

        [Authorize(Roles = "Admin,Manufacturer")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manufacturer")]
        public async Task<IActionResult> Create(PartViewModel model, IFormFile ImageFile)
        {
            string imagePath = null;

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

                imagePath = $"/uploads/{uniqueFileName}";
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var part = new Part
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImageUrl = imagePath,
                Price = model.Price,
                Quantity = model.Quantity,
                UserId = user.Id,
                User = user
            };

            _partRepository.Create(part);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manufacturer")]
        public IActionResult Edit(Guid id)
        {
            var part = _partRepository.GetPartById(id);
            if (part == null)
            {
                return NotFound();
            }

            var model = new PartViewModel
            {
                Id = part.Id,
                Name = part.Name,
                ImageUrl = part.ImageUrl,
                Quantity = part.Quantity,
                Price = part.Price
            };

            return View(model);
        }

        [Authorize(Roles = "Admin,Manufacturer")]
        public IActionResult Delete(Guid id)
        {
            var part = _partRepository.GetPartById(id);
            if (part == null)
            {
                return NotFound();
            }

            _partRepository.Delete(part);

            return RedirectToAction("Index", "Part");
        }
    }
}
