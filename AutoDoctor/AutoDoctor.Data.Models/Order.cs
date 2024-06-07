using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Status = "Pending";
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Status { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ICollection<OrderOffer> OrderOffers { get; set; } = new List<OrderOffer>();
        public ApplicationUser User { get; set; } = null!;
    }
}
