using AutoDoctor.Data.Models;

namespace AutoDoctor.Web.ViewModels.Part
{
    public class PartViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public ApplicationUser Manufacturer { get; set; } = null!;
    }
}
