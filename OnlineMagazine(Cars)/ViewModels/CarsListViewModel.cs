using InternetMagazin.Data.Models;
using System.Collections.Generic;

namespace InternetMagazin.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string currCategory { get; set; }
    }
}
