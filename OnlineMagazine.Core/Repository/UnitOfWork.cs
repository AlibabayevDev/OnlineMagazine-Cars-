using OnlineMagazine.Data;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Repository;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Core.Interfaces;
using OnlineMagazine.Core.Repository;

namespace OnlineMagazine.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContent appDbConent;
        public UnitOfWork(AppDbContent appDbConent)
        {
            this.appDbConent = appDbConent;
        }
        public IAllCars AllCars => new CarRepository(appDbConent);

        public IAllUsers AllUsers => new UsersRepository(appDbConent);

        public ICarsCategory Categories => new CategoryRepository(appDbConent);

        public IAllOrders AllOrders => new OrderRepository(appDbConent,this);

        public IShopCart ShopCart => new ShopCart(appDbConent);
    }
}
