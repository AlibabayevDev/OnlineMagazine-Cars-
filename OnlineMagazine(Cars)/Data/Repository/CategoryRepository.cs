using InternetMagazin.Data.Interfaces;
using InternetMagazin.Data.Models;
using System.Collections.Generic;

namespace InternetMagazin.Data.Repository
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
