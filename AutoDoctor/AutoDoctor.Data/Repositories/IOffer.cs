using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Repositories
{
    public interface IOffer
    {
        public void AddOffer();
        public void UpdateOffer();
        public void DeleteOffer();
        public void GetOffer();

    }
}
