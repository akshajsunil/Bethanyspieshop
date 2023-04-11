using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderReposiitory _orderReposiitory;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderReposiitory orderReposiitory, IShoppingCart shoppingCart)
        {
            _orderReposiitory = orderReposiitory;
            _shoppingCart = shoppingCart;
        }   
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems=items;
            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty fill some pies!");

            }
            if(ModelState.IsValid)
            {
                _orderReposiitory.createOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");

            }
            
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thx for ordering, completed checkout";
            return View();
        }
    }
}
