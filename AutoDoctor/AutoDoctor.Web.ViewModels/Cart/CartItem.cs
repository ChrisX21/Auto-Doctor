using AutoDoctor.Data.Models;

namespace AutoDoctor.Web.ViewModels.Cart
{
    public class CartItem
    {
        public Guid OfferId { get; set; }
        public Offer Offer { get; set; } = null!;
        public int Quantity { get; set; }
    }

}
