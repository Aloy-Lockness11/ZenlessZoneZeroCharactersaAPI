using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenlessZoneZeroCharacterAPI.Models;

namespace ZenlessZoneZeroCharacterAPI.Services
{
    public class ItemService
    {
        private readonly ZZZCharactersContext _context;

        public ItemService(ZZZCharactersContext context)
        {
            _context = context;
        }

        // Method to get all items with their associated properties
        public async Task<List<ItemDTO>> GetAllItems()
        {
            var items = await _context.Items.ToListAsync();

            // Map to ItemDTOs
            return items.Select(item => new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                AddedDamage = item.AddedDamage,
                AddedHealth = item.AddedHealth
            }).ToList();
        }

        // Method to get a single item with its properties
        public ItemDTO GetItemById(int id)
        {
            var item = _context.Items.Find(id);

            if (item == null)
                return null;

            // Map to ItemDTO
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                AddedDamage = item.AddedDamage,
                AddedHealth = item.AddedHealth
            };
        }
    }
}
