using AutoDoctor.Data.Models;
using System.Collections;

namespace AutoDoctor.Data.Repositories
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> GetAllOffers();
        Offer GetOfferById(Guid OfferId);
        Task AddOffer(Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(Guid OfferId);
    }
}
