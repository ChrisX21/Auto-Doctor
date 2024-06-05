using AutoDoctor.Data.Models;

namespace AutoDoctor.Web.ViewModels.Part
{
    public class PartViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public ApplicationUser Manufacturer { get; set; } = null!;
    }
}
