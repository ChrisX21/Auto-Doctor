using Microsoft.AspNetCore.Identity;

namespace AutoDoctor.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();    
    }
}
