using OnlineMagazine.Core.Services.Contacts;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazine.Core.Services.Implementations
{
    public class CarsService : ICarsService
    {
        private readonly IUnitOfWork db;

        public CarsService(IAllCars iAllCars, ICarsCategory iCarsCat, IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<Car> GetAll(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = db.AllCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("Electro", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = db.AllCars.Cars.Where(i => i.categoryId.Equals(1)).OrderBy(i => i.Id);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("Fuel", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = db.AllCars.Cars.Where(i => i.categoryId.Equals(2)).OrderBy(i => i.Id);
                    currCategory = "Классические автомобили";
                }
            }

            return cars;
        }
    }
}
