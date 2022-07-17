using OnlineMagazine.Data.Models;
using System.Collections.Generic;

namespace OnlineMagazine.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFaVCars { get; }
        Car GetObjectCar(int carId);
    }
}
