using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Repository;
using OnlineMagazine.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OnlineMagazine.Core.Repository;

namespace OnlineMagazine.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart,
            };

            return View(obj);
        }
        
        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);

            if(item !=null)
            {
                _shopCart.AddToCard(item);
            }
            return RedirectToAction("Index");
        }
    }
}
