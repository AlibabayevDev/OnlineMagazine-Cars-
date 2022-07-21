using OnlineMagazine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazine.Core.Services.Contacts
{
    public interface ICarsService
    {
        IEnumerable<Car> GetAll(string category);
    }
}
