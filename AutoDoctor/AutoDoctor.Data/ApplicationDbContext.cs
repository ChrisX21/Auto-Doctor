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
        public DbSet<Part> Parts { get; set; }
        public DbSet<OrderOffer> OrderOffers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderOffer>()
                .HasKey(oo => new { oo.OrderId, oo.OfferId });

            builder.Entity<Offer>()
                .HasOne(o => o.Part)
                .WithMany(p => p.Offers)
                .HasForeignKey(o => o.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Offer>()
                .HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
