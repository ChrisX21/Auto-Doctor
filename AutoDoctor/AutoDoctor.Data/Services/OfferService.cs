using AutoDoctor.Data.Repositories;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoDoctor.Data.Models;

namespace AutoDoctor.Data.Services
{
    public class OfferService : IOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOffer(Guid OfferId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offer> GetAllOffers() => _context.Offers;

        public Task GetOfferById(Guid OfferId)
        {
            return _context.Offers.Where(offer => OfferId == offer.Id).Select(offer => new Offer
            {
                Id = offer.Id,
                ImageUrl = offer.ImageUrl,
                CreatedAt = offer.CreatedAt,
                Title = offer.Title,
                Description = offer.Description,
                Price = offer.Price,
                Views = offer.Views,
                Likes = offer.Likes,
                User = offer.User,
                Vehicles = offer.Vehicles

            }).FirstOrDefaultAsync();
        }

        public Task UpdateOffer(Guid OfferId)
        {
            throw new NotImplementedException();
        }
    }
}
