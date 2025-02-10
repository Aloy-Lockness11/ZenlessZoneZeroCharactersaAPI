using Microsoft.EntityFrameworkCore;
using ZenlessZoneZeroCharacterAPI.Models;

namespace ZenlessZoneZeroCharacterAPI.Services
{
    
    public class CharacterService
    {
        private readonly ZZZCharactersContext _context;

        public CharacterService(ZZZCharactersContext context)
        {
            _context = context;
        }
    // Fetch all characters with their items and map them to DTOs
    public async Task<List<CharacterDTO>> GetAllCharactersWithItems()
    {
        var characters = await _context.Characters
                                        .Include(c => c.Items)  // Eager load Items
                                        .ToListAsync();

        // Map the characters to CharacterDTOs and include their items as ItemDTOs
        var characterDtos = characters.Select(character => new CharacterDTO
        {
            Id = character.Id,
            Name = character.Name,
            Type = character.Type,
            Element = character.Element,
            Health = character.Health,
            Damage = character.Damage,
            Items = character.Items.Select(item => new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                AddedDamage = item.AddedDamage,
                AddedHealth = item.AddedHealth
            }).ToList()
        }).ToList();

        return characterDtos;
    }

    public CharacterDTO GetCharacterWithItems(int characterId)
        {
            // Get the character with the items from the database
            var character = _context.Characters
                                    .Include(c => c.Items) // Eager load the Items
                                    .FirstOrDefault(c => c.Id == characterId);

            if (character == null)
            {
                return null; // Or handle error appropriately
            }

            // Map to DTO
            var characterDto = new CharacterDTO
            {
                Id = character.Id,
                Name = character.Name,
                Type = character.Type,
                Element = character.Element,
                Health = character.Health,
                Damage = character.Damage,
                Items = character.Items.Select(item => new ItemDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = item.Type,
                    AddedDamage = item.AddedDamage,
                    AddedHealth = item.AddedHealth

                }).ToList() // Map the items to DTOs
            };

            return characterDto;
        }
    }
}
