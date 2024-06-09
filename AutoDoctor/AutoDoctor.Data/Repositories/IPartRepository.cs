using AutoDoctor.Data.Models;

namespace AutoDoctor.Data.Repositories
{
    public interface IPartRepository
    {
        List<Part> GetAllPartsAsync();
        Part GetPartByIdAsync(Guid partId);
    }
}
