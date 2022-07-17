using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMagazine.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent appDbConent;
        public CarRepository(AppDbContent appDbConent)
        {
            this.appDbConent = appDbConent;
        }
        public IEnumerable<Car> Cars => appDbConent.Car;

        public IEnumerable<Car> GetFaVCars => appDbConent.Car.Where(p => p.IsFavourite);

        public Car GetObjectCar(int carId) => appDbConent.Car.FirstOrDefault(p =>p.Id == carId);
    }
}
