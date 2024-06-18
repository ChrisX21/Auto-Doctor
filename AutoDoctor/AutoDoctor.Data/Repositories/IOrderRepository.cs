using AutoDoctor.Data.Models;

namespace AutoDoctor.Data.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        void UpdateOrderStatus(Guid orderId);
        void CancelOrder(Guid orderId);
        Order GetOrderById(Guid orderId);
    }
}
