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
            return _context.Offers.FirstOrDefaultAsync(offer => offer.Id == OfferId);
        }


        public Task UpdateOffer(Guid OfferId)
        {
            throw new NotImplementedException();
        }
    }
}
