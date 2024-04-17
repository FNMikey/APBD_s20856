using Microsoft.AspNetCore.Mvc;
namespace WebApplication1;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal { Id = 1, Name = "Reksio", Category = "Pies", Weight = 30, FurColor = "Brązowy" },
        new Animal { Id = 2, Name = "Pluto", Category = "Kot", Weight = 15, FurColor = "Żółty" }
    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound($"Animal with id: {id} was not found");
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult PostAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var index = _animals.FindIndex(a => a.Id == id);
        if (index == -1)
            return NotFound();

        _animals[index] = animal;
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var index = _animals.FindIndex(a => a.Id == id);
        if (index == -1)
            return BadRequest();

        _animals.RemoveAt(index);
        return Ok();
    }
}
