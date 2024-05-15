using AnimalsSql.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsSql.Controllers
{
    public class AnimalsController : Controller
    {

        private IAnimalsService _animalsService;

        public AnimalsController(IAnimalsService animalsService)
        {
            _animalsService = animalsService; 
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animals = _animalsService.GetAnimals();
            return Ok(animals);
        }
    }
}
