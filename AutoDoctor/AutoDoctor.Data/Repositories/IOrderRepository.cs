namespace AutoDoctor.Data.Repositories
{
    public interface IOrderRepository
    {
        public void AddOrder();
        public void UpdateOrderStatus(Guid OrderId);
        public void CancelOrder(Guid OrderId);
    }
}
