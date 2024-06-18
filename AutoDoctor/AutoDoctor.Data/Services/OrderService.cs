using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoDoctor.Data.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void CancelOrder(Guid orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.Status = "Cancelled";
                _context.SaveChanges();
            }
        }

        public void UpdateOrderStatus(Guid orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.Status = "Updated"; // Set appropriate status
                _context.SaveChanges();
            }
        }

        public Order GetOrderById(Guid orderId)
        {
            return _context.Orders
                .Include(o => o.OrderOffers)
                .ThenInclude(oo => oo.Offer)
                .FirstOrDefault(o => o.Id == orderId);
        }
    }
}
