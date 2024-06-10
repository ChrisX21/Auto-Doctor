using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AutoDoctor.Data.Models;
using System.Net;

namespace AutoDoctor.Pages.Identity.Account.Manage
{
    public class ChangeRoleModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangeRoleModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public string SelectedRole { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            UserId = user?.Id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRoleAsync(user, SelectedRole);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "User not found");
            return Page();
        }
    }
}
