using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryManagement.Data;
using ProductInventoryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;

namespace ProductInventoryManagement.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/inventory
        [HttpGet]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventory()
        {
            return await _context.Inventories.Include(i => i.Product).ToListAsync();
        }

        // POST: api/v1/inventory
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Inventory>> AdjustInventory(Inventory inventory)
        {
            var product = await _context.Products.FindAsync(inventory.ProductID);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }

            inventory.LastUpdated = DateTime.UtcNow;

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInventory), new { id = inventory.InventoryID }, inventory);
        }
    }
}
