using AutoDoctor.Data.Models;
using System.Collections;

namespace AutoDoctor.Data.Repositories
{
    public interface IOfferRepository
    {
        public IEnumerable<Offer> GetAllOffers();
        public Task AddOffer(Offer offer);
        public Task UpdateOffer(Guid OfferId);
        public Task DeleteOffer(Guid OfferId);
        public Task GetOfferById(Guid OfferId);

    }
}
