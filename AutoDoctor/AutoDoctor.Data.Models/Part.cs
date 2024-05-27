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
        public string Name { get; set; } = null!;
        [ForeignKey(nameof(User)), Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(Vehicle)), Required]
        public Guid VehicleId { get; set; } 
        public string ImageUrl { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
