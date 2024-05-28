using System.ComponentModel.DataAnnotations;

namespace AutoDoctor.Data.Models
{
    public class PartVehicle
    {
        public Guid PartId { get; set; }
        public Guid VehicleId { get; set; }

        public Part Part { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
    }
}
