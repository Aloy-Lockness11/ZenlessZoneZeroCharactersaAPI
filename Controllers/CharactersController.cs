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
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly ZZZCharactersContext _context;

        public CharactersController(ZZZCharactersContext context, CharacterService characterService)
        {
            _context = context;
            //make sure to inject the service
            _characterService = characterService ?? throw new ArgumentNullException(nameof(characterService));
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            var charactersDto = await _characterService.GetAllCharactersWithItems(); // You may need to implement this method

            if (charactersDto == null || !charactersDto.Any())
            {
                return NotFound();
            }

            return Ok(charactersDto); // Returning the list of DTOs
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            var characterDto = _characterService.GetCharacterWithItems(id); // Get the single DTO

            if (characterDto == null)
            {
                return NotFound();
            }

            return Ok(characterDto); // Returning the DTO of the single character
        }

        // PUT: api/Characters/5/assign-items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/assign-items")]
        public async Task<IActionResult> AssignItemsToCharacter(int id, [FromBody] List<int> itemIds)
        {
            if (itemIds == null || !itemIds.Any())
            {
                return BadRequest("No item IDs provided.");
            }

            // Fetch the character including its current items
            var character = await _context.Characters.Include(c => c.Items)
                                                     .FirstOrDefaultAsync(c => c.Id == id);
            if (character == null)
            {
                return NotFound("Character not found.");
            }

            // Fetch the items to assign
            var itemsToAssign = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();

            // Check if all items were found
            if (itemsToAssign.Count != itemIds.Count)
            {
                return NotFound("One or more items not found.");
            }

            // Assign the items to the character
            character.Items.AddRange(itemsToAssign);
            await _context.SaveChangesAsync();

            // Include the updated character with the assigned items in the response
            var updatedCharacter = new CharacterDTO
            {
                Id = character.Id,
                Name = character.Name,
                Type = character.Type,
                Element = character.Element,
                Health = character.Health,
                Damage = character.Damage,
                Items = character.Items.Select(item => new ItemMinimalDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = item.Type,
                    AddedDamage = item.AddedDamage,
                    AddedHealth = item.AddedHealth,
                }).ToList()
            };

            // Return 201 Created with the updated character and the Location header pointing to the character resource
            return CreatedAtAction(nameof(GetCharacter), new { id = updatedCharacter.Id }, updatedCharacter);
        }


        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> PostCharacters([FromBody] CharacterDTO characterDto)
        {
            if (characterDto == null)
            {
                return BadRequest("Character data is null");
            }

            // Create the character without items
            var createdCharacter = await _characterService.CreateCharacterWithoutItems(characterDto);

            if (createdCharacter == null)
            {
                return BadRequest("Failed to create character");
            }

            // Return a Created response with the location of the newly created character
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            // Find the character by ID
            var character = await _context.Characters.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);

            // If character doesn't exist, return NotFound
            if (character == null)
            {
                return NotFound();
            }

            character.Items.Clear();

            // Remove the character
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content - Successfully deleted
        }

    }

}
