using OnlineMagazine.Data.Models;
using System.Collections.Generic;

namespace OnlineMagazine.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string currCategory { get; set; }
    }
}
