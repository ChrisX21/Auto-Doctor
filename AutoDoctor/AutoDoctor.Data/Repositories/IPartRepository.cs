using AutoDoctor.Data.Models;

namespace AutoDoctor.Data.Repositories
{
    public interface IPartRepository
    {
        void Create(Part part);
        List<Part> GetAllParts();
        Part GetPartById(Guid partId);
        void Update(Part part);
        void Delete(Part part);
    }
}
