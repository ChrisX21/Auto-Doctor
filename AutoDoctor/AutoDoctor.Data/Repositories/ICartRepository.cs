using AutoDoctor.Web.ViewModels.Cart;

namespace AutoDoctor.Data.Repositories
{
    public interface ICartRepository
    {
        void AddToCart(Guid offerId, int quantity);
        void RemoveFromCart(Guid offerId);
        List<CartItem> GetCartItems();
        void ClearCart();
    }
}
