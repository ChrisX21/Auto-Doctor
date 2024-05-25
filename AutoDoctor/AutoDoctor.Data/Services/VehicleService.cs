using AutoDoctor.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Services
{
    public class VehicleService : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddVehicle()
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle()
        {
            throw new NotImplementedException();
        }

        public void GetVehicle()
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
