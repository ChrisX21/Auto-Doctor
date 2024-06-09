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

        public void Create(Part part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part));
            }

            _context.Parts.Add(part);
            _context.SaveChanges();
        }

        public List<Part> GetAllParts()
        {
            return _context.Parts.ToList();
        }

        public Part GetPartById(Guid partId)
        {
            return _context.Parts.FirstOrDefault(part => part.Id == partId);
        }

        public void UpdateQuantity(Part part, int quantity)
        {
            part.Quantity = quantity;
            _context.Update(part);
            _context.SaveChanges();
        }
    }
}

