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
        public string Description { get; set; } = null!;
        [ForeignKey(nameof(Part))]
        public Guid PartId { get; set; }
        public Part Part { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public ICollection<OrderOffer> OrderOffers { get; set; } = new List<OrderOffer>();
    }
}
