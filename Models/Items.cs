using System.ComponentModel.DataAnnotations;

namespace ZenlessZoneZeroCharacterAPI.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("^(Weapon|Accessory)$", ErrorMessage = "Invalid Type. Type Should be of type Weapon, Accessory")]
        public string? Type { get; set; }

        public int? AddedDamage { get; set; }

        public int? AddedHealth { get; set; }

        [Required]
        [RegularExpression("^(Health|Damage)$", ErrorMessage = "Invalid Bonus Type. Type Should be of type Health, Damage")]
        public int? BonusType { get; set; }

        [Required]
        public int? BonusValue { get; set; }
    }
}
