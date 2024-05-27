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
        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Price { get; set; } = 0;
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public ApplicationUser User { get; set; } = null!;
    }
}
