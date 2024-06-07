using AutoDoctor.Data.Models;
using AutoDoctor.Web.ViewModels.Part;

namespace AutoDoctor.Web.ViewModels.Marketplace
{
    public class AllOffersViewModel
    {
        public Guid OfferId { get; set; }
        public string Description { get; set; } = null!;
        public PartViewModel Part { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
