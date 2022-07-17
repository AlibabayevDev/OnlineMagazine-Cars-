using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using System.Collections.Generic;

namespace OnlineMagazine.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDbContent appDbConent;
        public CategoryRepository(AppDbContent appDbConent)
        {
            this.appDbConent = appDbConent;
        }
        public IEnumerable<Category> AllCategories =>appDbConent.Category;
    }
}
