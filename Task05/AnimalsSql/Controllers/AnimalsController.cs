using AnimalsSql.Models;
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

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            var affectedCount = _animalsService.CreateAnimal(animal);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{idAnimal:int}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {
            var affectedCount = _animalsService.DeleteAnimal(idAnimal);
            if (affectedCount == 0)
                return NotFound($"Animal with id {idAnimal} not found");
            return NoContent();
        }


        [HttpPut("{idAnimal:int}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int idAnimal)
        {
            var affectedCount = _animalsService.UpdateAnimal(animal, idAnimal);
            if (affectedCount == 0)
                return NotFound($"Animal with id {idAnimal} not found");
            return NoContent();
        }
    }
}
