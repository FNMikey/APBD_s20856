using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : ControllerBase
    {
        private static List<Visit> visits = new()
    {
        new Visit { Id = 1, Date = DateTime.Parse("2023-04-15"), AnimalId = 1, Description = "Wizyta kontrolna", Price = 100 },
        new Visit { Id = 2, Date = DateTime.Parse("2023-05-01"), AnimalId = 2, Description = "Strzyżenie", Price = 200 },
        new Visit { Id = 3, Date = DateTime.Parse("2023-05-02"), AnimalId = 3, Description = "Higiena", Price = 75 }
    };

        [HttpGet]
        public ActionResult<List<Visit>> Get()
        {
            return visits;
        }

        [HttpGet("byAnimal/{animalId}")]
        public ActionResult<List<Visit>> GetByAnimalId(int animalId)
        {
            var animalVisits = visits.Where(v => v.AnimalId == animalId).ToList();
            if (animalVisits.Count == 0)
                return NotFound("No visits found for this animal.");

            return animalVisits;
        }

        [HttpPost]
        public ActionResult<Visit> Post(Visit visit)
        {
            visits.Add(visit);
            return CreatedAtAction(nameof(Get), new { id = visit.Id }, visit);
        }
    }

}
