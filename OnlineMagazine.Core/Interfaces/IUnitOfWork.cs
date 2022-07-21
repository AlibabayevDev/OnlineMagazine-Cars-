using OnlineMagazine.Core.Interfaces;
using OnlineMagazine.Data.Interfaces;

namespace OnlineMagazine.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IAllUsers AllUsers { get; }
        ICarsCategory Categories { get; }
        IAllCars AllCars { get; }
        IAllOrders AllOrders { get; }
        IShopCart ShopCart { get; }
    }
}
