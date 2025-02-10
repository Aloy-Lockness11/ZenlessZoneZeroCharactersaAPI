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

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacters(int id, Characters characters)
        {
            if (id != characters.Id)
            {
                return BadRequest();
            }

            _context.Entry(characters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharactersExists(id))
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

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Characters>> PostCharacters(Characters characters)
        {
            _context.Characters.Add(characters);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacters), new { id = characters.Id }, characters);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacters(int id)
        {
            var characters = await _context.Characters.FindAsync(id);
            if (characters == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(characters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharactersExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }

}
