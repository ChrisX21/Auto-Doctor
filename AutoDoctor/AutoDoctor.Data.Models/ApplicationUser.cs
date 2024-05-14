using Microsoft.AspNetCore.Identity;

namespace AutoDoctor.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
