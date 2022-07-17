using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMagazine.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopCartItems();
            if(shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }
            if(ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();  
        }
    }
}
