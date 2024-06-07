using AutoDoctor.Data.Models;
using System.Collections;

namespace AutoDoctor.Data.Repositories
{
    public interface IOfferRepository
    {
        public IEnumerable<Offer> GetAllOffers();
        public Offer GetOfferById(Guid OfferId);
        public Task AddOffer(Offer offer);
        public void UpdateOffer(Guid OfferId);
        public void DeleteOffer(Guid OfferId);

    }
}
