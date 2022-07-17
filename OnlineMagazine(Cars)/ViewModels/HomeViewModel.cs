using InternetMagazin.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace InternetMagazin.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
