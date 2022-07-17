using OnlineMagazine.Data;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Repository;
using OnlineMagazine.Data.Interfaces;

namespace OnlineMagazine.Data.Repository
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
