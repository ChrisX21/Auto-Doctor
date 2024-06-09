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
            return _context.Parts.Include(p => p.User).ToList();
        }

        public Part GetPartById(Guid partId)
        {
            return _context.Parts.Include(p => p.User).FirstOrDefault(part => part.Id == partId);
        }

        public void Update(Part part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part));
            }

            _context.Parts.Update(part);
            _context.SaveChanges();
        }

        public void Delete(Part part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part));
            }

            _context.Parts.Remove(part);
            _context.SaveChanges();
        }
    }
}
