using InternetMagazin.Data.Interfaces;
using InternetMagazin.Data.Models;
using InternetMagazin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OnlineMagazine_Cars_.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InternetMagazin.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCarsCategory;
        private readonly IUnitOfWork db;

        public CarsController(IAllCars iAllCars,ICarsCategory iCarsCat,IUnitOfWork db)
        {
            this.db = db;
            _allCars = iAllCars;
            _allCarsCategory = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category= category;
            IEnumerable<Car> cars = null; 
            string currCategory = "";
            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("Electro",category,System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = db.AllCars.Cars.Where(i => i.categoryId.Equals(1)).OrderBy(i => i.Id);
                    currCategory = "Электромобили";
                } else if (string.Equals("Fuel", category, System.StringComparison.OrdinalIgnoreCase)){
                    cars = _allCars.Cars.Where(i => i.categoryId.Equals(2)).OrderBy(i => i.Id);
                    currCategory= "Классические автомобили";
                }
            }

            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currCategory = currCategory,
            };

            ViewBag.Title = "Stranica avtomobilami";

            return View(carObj);
        }

        public IActionResult AddToCars(Car model)
        {
            return View();
        }

    }
}
