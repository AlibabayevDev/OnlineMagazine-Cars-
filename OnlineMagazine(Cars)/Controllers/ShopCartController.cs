using InternetMagazin.Data.Interfaces;
using InternetMagazin.Data.Models;
using InternetMagazin.Data.Repository;
using InternetMagazin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InternetMagazin.Controllers
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
