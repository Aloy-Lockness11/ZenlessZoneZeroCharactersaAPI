using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenlessZoneZeroCharacterAPI.Models;
using ZenlessZoneZeroCharacterAPI.Services;

namespace ZenlessZoneZeroCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly ZZZCharactersContext _context;

        public ItemsController(ZZZCharactersContext context, ItemService itemService)
        {
            _context = context;
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {
            var itemsDto = await _itemService.GetAllItems(); // Use service to get all items

            if (itemsDto == null || !itemsDto.Any())
            {
                return NotFound();
            }

            return Ok(itemsDto); // Returning the list of ItemDTOs
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(int id)
        {
            var itemDto = _itemService.GetItemById(id); // Use service to get a single item

            if (itemDto == null)
            {
                return NotFound();
            }

            return Ok(itemDto); // Returning the ItemDTO for the single item
        }

    

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, Items items)
        {
            if (id != items.Id)
            {
                return BadRequest();
            }

            _context.Entry(items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Items>> PostItems(Items items)
        {
            _context.Items.Add(items);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItems), new { id = items.Id }, items);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItems(int id)
        {
            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.Items.Remove(items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
