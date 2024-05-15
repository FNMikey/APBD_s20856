using AnimalsSql.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsSql.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
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
