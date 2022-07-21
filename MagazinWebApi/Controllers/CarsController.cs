using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMagazine.Core.Services.Contacts;
using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MagazinWebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }


        [HttpGet]
        public IActionResult List(string category)
        {
            try
            {
                var carsModels = carsService.GetAll(category);

                return Ok(carsModels);
            }
            catch
            {
                return BadRequest("Unknown error occured");
            }
            
        }

        [HttpPost]
        public IActionResult Save(Car car)
        {
            return Ok("her sey duzdu qaqa");
        }
    }
}
