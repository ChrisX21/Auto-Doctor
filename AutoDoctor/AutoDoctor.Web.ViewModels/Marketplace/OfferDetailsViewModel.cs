using AutoDoctor.Data.Models;
using AutoDoctor.Web.ViewModels.Vehicle;
namespace AutoDoctor.Web.ViewModels.Marketplace
{
    public class OfferDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public ApplicationUser User { get; set; } = null!;
        public ICollection<VehicleViewModel> Vehicle { get; set; } = null!;
    }
}
