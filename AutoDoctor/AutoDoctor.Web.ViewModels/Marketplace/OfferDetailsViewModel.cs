using AutoDoctor.Data.Models;
namespace AutoDoctor.Web.ViewModels.Marketplace
{
    public class OfferDetailsViewModel
    {
        public Guid Id { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public ApplicationUser Seller { get; set; } = null!;
    }
}
