using AutoDoctor.Data.Repositories;
using AutoDoctor.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace AutoDoctor.Data.Services
{
    public class CartService : ICartRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddToCart(Guid offerId, int quantity)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.OfferId == offerId);

            if (cartItem == null)
            {
                cart.Add(new CartItem { OfferId = offerId, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(Guid offerId)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.OfferId == offerId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }
            SaveCart(cart);
        }

        public List<CartItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            return JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        }

        public void ClearCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.Remove(CartSessionKey);
        }

        private void SaveCart(List<CartItem> cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = JsonConvert.SerializeObject(cart);
            session.SetString(CartSessionKey, cartJson);
        }
    }

}
