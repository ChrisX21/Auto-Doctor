using Microsoft.AspNetCore.Identity;

namespace AutoDoctor.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
