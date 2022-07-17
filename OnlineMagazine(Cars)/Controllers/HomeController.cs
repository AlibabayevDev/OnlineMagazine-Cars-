using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models.Entities;
using OnlineMagazine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMagazine.Controllers
{
    [Authorize(Roles ="A,SA")]
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                favCars = _carRep.Cars,
            };
            return View(homeCars);
        }
    }
}
