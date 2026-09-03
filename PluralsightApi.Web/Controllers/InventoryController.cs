using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PluralsightApi.Web.Models;
using PluralsightApi.Web.Services;

namespace PluralsightApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("/{id}")]
        public ActionResult<LocationInventory> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            
            var inventory = _inventoryService.GetLocationInventory(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<LocationInventory>> Get()
        {
            var inventory = _inventoryService.ListLocationInventory();

            return Ok(inventory);
        }
    }
}
