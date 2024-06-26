﻿using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoDoctor.Data.Services
{
    public class OfferService : IOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public OfferService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOffer(Offer offer)
        {
            Offer newOffer = new Offer
            {
                Id = Guid.NewGuid(),
                Description = offer.Description,
                Part = offer.Part,
                User = offer.User
            };

            await _context.Offers.AddAsync(newOffer);
            await _context.SaveChangesAsync();
        }

        public void DeleteOffer(Guid offerId)
        {
            var offer = GetOfferById(offerId);
            _context.Remove(offer);
            _context.SaveChanges();
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            return _context.Offers.Include(o => o.Part).Include(o => o.User);
        }

        public Offer GetOfferById(Guid offerId)
        {
            return _context.Offers.Include(o => o.Part).Include(o => o.User).FirstOrDefault(offer => offer.Id == offerId);
        }

        public void UpdateOffer(Offer offer)
        {
            _context.Offers.Update(offer);
            _context.SaveChanges();
        }
    }
}
