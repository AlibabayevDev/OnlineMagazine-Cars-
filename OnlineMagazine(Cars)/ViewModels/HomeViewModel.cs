using OnlineMagazine.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace OnlineMagazine.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
