using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Part;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PartViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var part = new Part
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                UserId = user.Id,
                User = user  
            };

            _partRepository.Create(part);

            return RedirectToAction("Index");
        }
    }
}
