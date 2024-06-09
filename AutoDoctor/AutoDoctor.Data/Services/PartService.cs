using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoDoctor.Data.Services
{
    public class PartService : IPartRepository
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Part> GetAllPartsAsync()
        {
            return _context.Parts.ToList();
        }

        public Part GetPartByIdAsync(Guid partId)
        {
            return _context.Parts.FirstOrDefault(part => part.Id == partId);
        }
    }
}

