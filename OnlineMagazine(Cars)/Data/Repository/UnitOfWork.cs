using InternetMagazin.Data;
using InternetMagazin.Data.Interfaces;
using InternetMagazin.Data.Models;
using InternetMagazin.Data.Repository;
using OnlineMagazine_Cars_.Data.Interfaces;

namespace OnlineMagazine_Cars_.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContent appDbConent;
        private readonly ShopCart shopCart;

        public UnitOfWork(AppDbContent appDbConent,ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appDbConent = appDbConent;
        }
        public IAllCars AllCars => new CarRepository(appDbConent);

        public IAllUsers AllUsers => new UsersRepository(appDbConent);

        public ICarsCategory Categories => new CategoryRepository(appDbConent);

        public IAllOrders AllOrders => new OrderRepository(appDbConent,shopCart);
    }
}
