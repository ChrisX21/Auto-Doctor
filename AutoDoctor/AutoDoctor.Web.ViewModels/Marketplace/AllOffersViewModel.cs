using AutoDoctor.Data.Models;
using AutoDoctor.Web.ViewModels.Vehicle;

namespace AutoDoctor.Web.ViewModels.Marketplace
{
    public class AllOffersViewModel
    {
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public ApplicationUser User { get; set; } = null!; 
    }
}
