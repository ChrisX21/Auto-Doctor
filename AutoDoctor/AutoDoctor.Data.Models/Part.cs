using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDoctor.Data.Models
{
    public class Part
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Quantity { get; set; }
        
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; } = 0;
        [ForeignKey(nameof(User)), Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
    }
}
