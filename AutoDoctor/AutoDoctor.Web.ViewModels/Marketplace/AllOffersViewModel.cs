using AutoDoctor.Data.Models;
using AutoDoctor.Web.ViewModels.Part;
using AutoDoctor.Web.ViewModels.Vehicle;

namespace AutoDoctor.Web.ViewModels.Marketplace
{
    public class AllOffersViewModel
    {
        public Guid OfferId { get; set; }
        public string Description { get; set; } = null!;
        public PartViewModel Part { get; set; } = null!;
    }
}
