using InternetMagazin.Data.Models.Entities;
using System.Collections.Generic;

namespace OnlineMagazine_Cars_.Data.Interfaces
{
    public interface IAllUsers
    {
        IEnumerable<User> Users { get;}

    }
}
