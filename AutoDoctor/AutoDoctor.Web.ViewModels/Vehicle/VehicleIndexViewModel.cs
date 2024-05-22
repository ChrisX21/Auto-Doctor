using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Web.ViewModels.Vehicle
{
    public class VehicleIndexViewModel
    {
        public IEnumerable<VehicleViewModel> Vehicles { get; set; } = null!;
    }
}
