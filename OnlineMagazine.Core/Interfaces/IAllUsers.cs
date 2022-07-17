using OnlineMagazine.Data.Models.Entities;
using System.Collections.Generic;

namespace OnlineMagazine.Data.Interfaces
{
    public interface IAllUsers
    {
        IEnumerable<User> Users { get;}

    }
}
