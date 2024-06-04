using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDoctor.Data.Models
{
    public class Offer
    {
        public Offer()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; } = new Guid();
        public DateTime CreatedAt { get; set; }
        [ForeignKey(nameof(Part))]
        public Guid PartId { get; set; }
        public Part Part { get; set; } = null!;
        public ICollection<OrderOffer> OrderOffers { get; set; } = new List<OrderOffer>();
    }
}
