using System.ComponentModel.DataAnnotations;

namespace AutoDoctor.Data.Models
{
    public class OrderOffer
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid OfferId { get; set; }
        public Offer Offer { get; set; } = null!;
    }
}
