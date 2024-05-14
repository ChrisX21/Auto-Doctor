using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Repositories
{
    public interface IOfferRepository
    {
        public void AddOffer();
        public void GetAllOffers();
        public void UpdateOffer(Guid OfferId);
        public void DeleteOffer(Guid OfferId);
        public void GetOfferById(Guid OfferId);

    }
}
