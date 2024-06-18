using AutoDoctor.Data.Models;
using AutoDoctor.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoDoctor.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOfferRepository _offerRepository;

        public CartController(ICartRepository cartRepository, IOrderRepository orderRepository, IOfferRepository offerRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _offerRepository = offerRepository;
        }

        public IActionResult Index()
        {
            var cartItems = _cartRepository.GetCartItems();
            return View(cartItems);
        }

        public IActionResult AddToCart(Guid offerId, int quantity)
        {
            _cartRepository.AddToCart(offerId, quantity);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(Guid offerId)
        {
            _cartRepository.RemoveFromCart(offerId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var cartItems = _cartRepository.GetCartItems();
            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = new Order
            {
                UserId = userId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            foreach (var cartItem in cartItems)
            {
                var offer = _offerRepository.GetOfferById(cartItem.OfferId);
                if (offer != null)
                {
                    order.OrderOffers.Add(new OrderOffer
                    {
                        Order = order,
                        Offer = offer
                    });
                }
            }

            _orderRepository.AddOrder(order);
            _cartRepository.ClearCart();

            return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }

        public IActionResult OrderConfirmation(Guid orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
