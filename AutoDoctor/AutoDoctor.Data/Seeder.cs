using AutoDoctor.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoDoctor.Data
{
    public class Seeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public Seeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedAsync()
        {
            await SeedRoles();
            var user = await SeedUsers();
            await SeedParts(user);
            await SeedOffers(user);
            await SeedOrders(user);
        }

        private async Task SeedRoles()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
                await _roleManager.CreateAsync(new IdentityRole("Seller"));
                await _roleManager.CreateAsync(new IdentityRole("Manufacturer"));
            }
        }

        private async Task<ApplicationUser> SeedUsers()
        {
            if (_userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };
                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, "Admin");
                return user;
            }

            return _userManager.Users.First();
        }

        private async Task SeedParts(ApplicationUser user)
        {
            if(!_context.Parts.Any())
            {
                var parts = new List<Part>
                {
                    new Part
                    {
                        Name = "Engine",
                        ImageUrl = "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/audi-porsche-engine.jpg",
                        Price = 5600m,
                        UserId = user.Id
                    },
                    new Part
                    {
                        Name = "Tires",
                        ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/pile-of-tires-on-white-background-royalty-free-image-672151801-1561751929.jpg?resize=2048:*",
                        Price = 489m,
                        UserId = user.Id
                    },
                    new Part
                    {
                        Name = "Brakes",
                        ImageUrl = "https://www.familyhandyman.com/wp-content/uploads/2020/03/Brake-Caliper-GettyImages-691429614.jpg",
                        Price = 299.99m,
                        UserId = user.Id 
                    }
                };

                _context.Parts.AddRange(parts);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedOffers(ApplicationUser user)
        {
            if (!_context.Offers.Any())
            {
                var part = _context.Parts.First();
                var offers = new List<Offer>
                {
                    new Offer
                    {
                        Description = "Audi 3.0 V6 engine, 198 000km",
                        Views = 100,
                        PartId = part.Id,
                        UserId = user.Id
                    },
                    new Offer
                    {
                        Description = "Michelin Pilot 1",
                        Views = 298,
                        PartId = part.Id,
                        UserId = user.Id
                    },
                    new Offer
                    {
                        Description = "Brembo 120mm brake kit",
                        Views = 261,
                        PartId = part.Id,
                        UserId = user.Id
                    }
                };

                _context.Offers.AddRange(offers);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedOrders(ApplicationUser user)
        {
            if (!_context.Orders.Any())
            {
                var offers = _context.Offers.ToList();
                var orders = new List<Order>
                {
                    new Order
                    {
                        Status = "Completed",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        UserId = user.Id,
                        OrderOffers = new List<OrderOffer>
                        {
                            new OrderOffer { OfferId = offers[0].Id },
                            new OrderOffer { OfferId = offers[1].Id }
                        }
                    }
                };

                _context.Orders.AddRange(orders);
                await _context.SaveChangesAsync();
            }
        }
    }
}
