namespace AutoDoctor.Data.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder();
        void UpdateOrderStatus(Guid OrderId);
        void CancelOrder(Guid OrderId);
    }
}
