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
        }

        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(Offer))]
        [Required]
        public Guid OfferId { get; set; }
        [Required]
        public Offer Offer { get; set; } = null!;
        public ApplicationUser User { get; set; }
    }
}
