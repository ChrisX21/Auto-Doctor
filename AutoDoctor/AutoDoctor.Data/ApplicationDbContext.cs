using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoDoctor.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AutoDoctor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Offer> Offers { get; set; } 
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartVehicle> partVehicles { get; set; }
        public DbSet<OrderOffer> OrderOffers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartVehicle>()
               .HasKey(pv => new { pv.PartId, pv.VehicleId });

            builder.Entity<OrderOffer>()
                .HasKey(oo => new { oo.OrderId, oo.OfferId });

            builder.Entity<Offer>(o =>
            {
                o.HasOne(o => o.Part)
                    .WithOne(p => p.Offer)
                    .HasForeignKey(o => o.PartId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
