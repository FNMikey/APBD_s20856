using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using WebApplication3.DAL;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {

        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public WarehousesController(IProductWarehouseRepository productWarehouseRepository)
        {
            _productWarehouseRepository = productWarehouseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostWarehouse(Product_Warehouse product_Warehouse)
        {
            switch (await _productWarehouseRepository.PostWarehouse(product_Warehouse))
            {
                case 0: return Ok("Record added successfully");
                case 1: return StatusCode(404, "There is no Product with that ID");
                case 2: return StatusCode(404, "There is no Warehouse with that ID");
                case 3: return StatusCode(404, "There is no such order");
                case 4: return StatusCode(404, "Order has already been completed");
                default: return StatusCode(400, "Something went wrong");
            }
        }
    }
}
