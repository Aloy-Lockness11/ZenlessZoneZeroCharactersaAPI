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
        public async Task<IActionResult> PutItemName(int id, [FromBody] ItemUpdateDTO itemUpdateDto)
        {
            // Find the item by ID
            var item = await _context.Items.FindAsync(id);

            // If item doesn't exist, return NotFound
            if (item == null)
            {
                return NotFound();
            }

            // Update the item name
            item.Name = itemUpdateDto.Name;

            // Mark the item entity as modified
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                // Save changes to the database
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
            var updatedItem = new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                AddedDamage = item.AddedDamage,
                AddedHealth = item.AddedHealth,
                BonusType = item.BonusType,
                BonusValue = item.BonusValue
            };

            return Ok(updatedItem); // 200 OK with updated item
        }


        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> PostItem([FromBody] ItemDTO itemDto)
        {
            if (itemDto == null)
            {
                return BadRequest("Item data is null");
            }

            var validBonusTypes = new List<string> { "Damage", "Health" };
            if (!validBonusTypes.Contains(itemDto.BonusType))
            {
                return BadRequest("Invalid BonusType.");
            }

            // Call the ItemService to add the new item
            var createdItem = await _itemService.CreateItem(itemDto);

            

            if (createdItem == null)
            {
                return BadRequest("Failed to create item");
            }

            // Return a Created response with the location of the newly created item
            return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            // Find the item by ID
            var item = await _context.Items.FindAsync(id);

            // If item doesn't exist, return NotFound
            if (item == null)
            {
                return NotFound();
            }

            // Remove the item
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content - Successfully deleted
        }


        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
