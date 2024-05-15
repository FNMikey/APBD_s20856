using Microsoft.AspNetCore.Mvc;

namespace AnimalsSql.Controllers
{
    public class AnimalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
