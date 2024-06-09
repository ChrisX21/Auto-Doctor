using AutoDoctor.Data.Models;
using AutoDoctor.Web.ViewModels.Part;
namespace AutoDoctor.Web.ViewModels.Marketplace
{
    public class OfferDetailsViewModel
    {
        public Guid OfferId { get; set; }
        public string Description { get; set; } = null!;
        public int Views { get; set; } = 0;
        public ApplicationUser Manufacturer { get; set; } = null!;
        public PartViewModel Part { get; set; } = null!;
        public List<PartViewModel> Parts { get; set; } = new List<PartViewModel>();
    }
}
