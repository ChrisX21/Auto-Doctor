using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoctor.Data.Repositories
{
    public interface IOrderRepository
    {
        public void AddOrder();
        public void UpdateOrderStatus(Guid OrderId);
        public void CancelOrder(Guid OrderId);
    }
}
