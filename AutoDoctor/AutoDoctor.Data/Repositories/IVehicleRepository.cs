using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Repositories
{
    public interface IVehicleRepository
    {
        public void AddVehicle();
        public void UpdateVehicle();
        public void DeleteVehicle();
        public void GetVehicle();
    }
}
