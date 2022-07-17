using OnlineMagazine.Data.Models;
using System.Collections.Generic;

namespace OnlineMagazine.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
