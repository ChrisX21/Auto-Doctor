using AutoDoctor.Data.Models;

namespace AutoDoctor.Data.Repositories
{
    public interface IVehicleRepository
    {
        public void AddVehicle(Vehicle vehicle);
        public void UpdateVehicle(Guid id);
        public void DeleteVehicle(Guid id);
        public Vehicle GetVehicle(Guid id);
    }
}
