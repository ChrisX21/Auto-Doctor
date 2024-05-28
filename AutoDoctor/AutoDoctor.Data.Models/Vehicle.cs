using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Make { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null!;
        [Required] 
        public string Engine { get; set; } = null!;
        [Required]
        public string FuelType { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public ICollection<PartVehicle> PartVehicles { get; set; } = new List<PartVehicle>();

    }
}
