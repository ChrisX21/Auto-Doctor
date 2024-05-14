using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoDoctor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDoctor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
