using Microsoft.EntityFrameworkCore;

namespace ZenlessZoneZeroCharacterAPI.Models
{
    public class ZZZCharactersContext : DbContext
    {
        public ZZZCharactersContext(DbContextOptions<ZZZCharactersContext> options) : base(options) { }

        public DbSet<Characters> Characters { get; set; }
        public DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between Characters and Items
            modelBuilder.Entity<Items>()
                .HasOne(i => i.Character)              // Each item has one Character (Navigation property)
                .WithMany(c => c.Items)                // A character can have many items
                .HasForeignKey(i => i.CharacterId)     // Foreign key property in Items
                .OnDelete(DeleteBehavior.Cascade);     // Define cascade delete behavior (optional)


            // Seed data for Characters
            modelBuilder.Entity<Characters>().HasData(
                new Characters { Id = 1, Name = "Billy Kid", Type = "Attack", Element = "Physical", Health = 1500, Damage = 250 },
                new Characters { Id = 2, Name = "Nicole Demara", Type = "Support", Element = "Ether", Health = 1200, Damage = 180 },
                new Characters { Id = 3, Name = "Soldier Eleven", Type = "Defence", Element = "Fire", Health = 2000, Damage = 150 },
                new Characters { Id = 4, Name = "Miyabi", Type = "Attack", Element = "Ice", Health = 1300, Damage = 300 }
            );

            // Seed data for Items and assign them to characters
            modelBuilder.Entity<Items>().HasData(
                new Items { Id = 1, Name = "Blaster Pistol", Type = "Weapon", AddedDamage = 50, AddedHealth = 0, BonusType = "Damage", BonusValue = 10, CharacterId = 1 },
                new Items { Id = 2, Name = "Energy Shield", Type = "Accessory", AddedDamage = 0, AddedHealth = 100, BonusType = "Health", BonusValue = 20, CharacterId = 2 },
                new Items { Id = 3, Name = "Flame Thrower", Type = "Weapon", AddedDamage = 70, AddedHealth = 0, BonusType = "Damage", BonusValue = 15, CharacterId = 3 },
                new Items { Id = 4, Name = "Ice Blade", Type = "Weapon", AddedDamage = 60, AddedHealth = 0, BonusType = "Damage", BonusValue = 20, CharacterId = 4 },
                new Items { Id = 5, Name = "Energy Booster", Type = "Accessory", AddedDamage = 0, AddedHealth = 50, BonusType = "Health", BonusValue = 10, CharacterId = 1 },
                new Items { Id = 6, Name = "Shield Generator", Type = "Accessory", AddedDamage = 0, AddedHealth = 150, BonusType = "Health", BonusValue = 30, CharacterId = 3 },
                new Items { Id = 7, Name = "Rapid Fire Rifle", Type = "Weapon", AddedDamage = 80, AddedHealth = 0, BonusType = "Damage", BonusValue = 12, CharacterId = 2 },
                new Items { Id = 8, Name = "Wind Sword", Type = "Weapon", AddedDamage = 90, AddedHealth = 0, BonusType = "Damage", BonusValue = 25, CharacterId = 4 },
                new Items { Id = 9, Name = "Healing Crystal", Type = "Accessory", AddedDamage = 0, AddedHealth = 200, BonusType = "Health", BonusValue = 50, CharacterId = 2 },
                new Items { Id = 10, Name = "Dragon Armor", Type = "Accessory", AddedDamage = 0, AddedHealth = 300, BonusType = "Health", BonusValue = 70, CharacterId = 3 },
                new Items { Id = 11, Name = "Energy Pulse Cannon", Type = "Weapon", AddedDamage = 120, AddedHealth = 0, BonusType = "Damage", BonusValue = 18, CharacterId = 1 },
                new Items { Id = 12, Name = "Ice Shield", Type = "Accessory", AddedDamage = 0, AddedHealth = 120, BonusType = "Health", BonusValue = 40, CharacterId = 4 },
                new Items { Id = 13, Name = "Phoenix Blade", Type = "Weapon", AddedDamage = 75, AddedHealth = 0, BonusType = "Damage", BonusValue = 17, CharacterId = 3 },
                new Items { Id = 14, Name = "Electric Gauntlets", Type = "Weapon", AddedDamage = 65, AddedHealth = 0, BonusType = "Damage", BonusValue = 12, CharacterId = 2 },
                new Items { Id = 15, Name = "Health Regenerator", Type = "Accessory", AddedDamage = 0, AddedHealth = 150, BonusType = "Health", BonusValue = 35, CharacterId = 1 },
                new Items { Id = 16, Name = "Dragon's Claw", Type = "Weapon", AddedDamage = 100, AddedHealth = 0, BonusType = "Damage", BonusValue = 22, CharacterId = 3 },
                new Items { Id = 17, Name = "Thunderstorm Hammer", Type = "Weapon", AddedDamage = 110, AddedHealth = 0, BonusType = "Damage", BonusValue = 20, CharacterId = 4 },
                new Items { Id = 18, Name = "Reflective Shield", Type = "Accessory", AddedDamage = 0, AddedHealth = 250, BonusType = "Health", BonusValue = 60, CharacterId = 3 },
                new Items { Id = 19, Name = "Energy Absorber", Type = "Accessory", AddedDamage = 0, AddedHealth = 80, BonusType = "Health", BonusValue = 15, CharacterId = 2 },
                new Items { Id = 20, Name = "Frostbite Armor", Type = "Accessory", AddedDamage = 0, AddedHealth = 220, BonusType = "Health", BonusValue = 50, CharacterId = 4 }
            );
        }
    }
}
