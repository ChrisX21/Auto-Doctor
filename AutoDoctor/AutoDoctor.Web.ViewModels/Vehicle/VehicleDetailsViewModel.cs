using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Web.ViewModels.Vehicle
{
    public class VehicleDetailsViewModel
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string Engine { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public string FuelType { get; set; } = null!;
    }
}
