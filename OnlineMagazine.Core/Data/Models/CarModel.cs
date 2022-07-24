using OnlineMagazine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazine.Core.Data.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public ushort Price { get; set; }
        public bool IsFavourite { get; set; }
        public bool Available { get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
