using AutoDoctor.Data.Models;
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

        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(Guid id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(Guid id) => _context.Vehicles.FirstOrDefault(v => v.Id == id);

        public void UpdateVehicle(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
