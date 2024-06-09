using AutoDoctor.Data.Models;

namespace AutoDoctor.Data.Repositories
{
    public interface IPartRepository
    {
        void Create(Part part);
        void UpdateQuantity(Part part, int quantity);
        List<Part> GetAllParts();
        Part GetPartById(Guid partId);
    }
}
