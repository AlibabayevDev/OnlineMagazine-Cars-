using InternetMagazin.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace InternetMagazin.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{categoryName ="Электромобили" , desc = "Sovremenniy vid transporta"},
                        new Category{categoryName ="Классические автомобили", desc = "Masini s dviqatelem vnutrennoqo sqoraniya"}
                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;
            }
        }
    }
}
