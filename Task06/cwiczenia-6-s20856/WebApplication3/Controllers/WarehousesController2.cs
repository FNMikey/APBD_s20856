using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DAL;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController2 : ControllerBase
    {

        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public WarehousesController2(IProductWarehouseRepository productWarehouseRepository)
        {
            _productWarehouseRepository = productWarehouseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostWarehouse(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt)
        {
            if (await _productWarehouseRepository.PostWarehouseAsync(IdProduct, IdWarehouse, Amount, CreatedAt) != 0)
                return Ok("Dodano");
            else
                return BadRequest("Coś poszło nie tak");
        }
    }
}
