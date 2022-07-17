using InternetMagazin.Data.Interfaces;

namespace OnlineMagazine_Cars_.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IAllUsers AllUsers { get; }
        ICarsCategory Categories { get; }
        IAllCars AllCars { get; }
        IAllOrders AllOrders { get; }
    }
}
