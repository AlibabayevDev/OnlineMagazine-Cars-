using InternetMagazin.Data.Models;
using System.Collections.Generic;

namespace InternetMagazin.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFaVCars { get; }
        Car GetObjectCar(int carId);
    }
}
