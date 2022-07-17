using InternetMagazin.Data.Models;
using System.Collections.Generic;

namespace InternetMagazin.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
