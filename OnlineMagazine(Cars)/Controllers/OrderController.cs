using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineMagazine.Core.Repository;

namespace OnlineMagazine.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            unitOfWork.ShopCart.ListShopItems = unitOfWork.ShopCart.GetShopCartItems();
            if(unitOfWork.ShopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }
            if(ModelState.IsValid)
            {
                unitOfWork.AllOrders.createOrder(order);
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
