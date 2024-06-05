using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Models
{
    public class Part
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; } = 0;
        [ForeignKey(nameof(User)), Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
        public ICollection<PartVehicle> PartVehicles { get; set; } = new List<PartVehicle>();
    }
}
