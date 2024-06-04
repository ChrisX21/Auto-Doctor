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

            builder.Entity<Offer>()
                .HasOne(o => o.Part)
                .WithMany(p => p.Offers)
                .HasForeignKey(o => o.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderOffer>()
                .HasOne(oo => oo.Order)
                .WithMany(o => o.OrderOffers)
                .HasForeignKey(oo => oo.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderOffer>()
                .HasOne(oo => oo.Offer)
                .WithMany(o => o.OrderOffers)
                .HasForeignKey(oo => oo.OfferId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasMany(o => o.OrderOffers)
                .WithOne(oo => oo.Order)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Offer>()
               .HasMany(o => o.OrderOffers)
               .WithOne(oo => oo.Offer)
               .HasForeignKey(oo => oo.OfferId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Part>()
                .HasMany(p => p.Offers)
                .WithOne(o => o.Part)
                .HasForeignKey(o => o.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
