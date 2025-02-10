using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ZenlessZoneZeroCharacterAPI.Models
{
    public class Characters
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        //zenlesszonezero charater types 
        [Required]
        [RegularExpression("^(Anomaly|Attack|Defence|Stun|Support)$", ErrorMessage = "Invalid Type. Type Should be of type Anomaly, Attack, Defence, Stun, Support")]
        public string? Type { get; set; }

        //zenlesszonezero charater elements
        [Required]
        [RegularExpression("^(Electric|Ether||Fire|Ice|Physical)$", ErrorMessage = "Invalid Element Element Should be of type Electric, Ether, Fire, Ice, Physical")]
        public String? Element { get; set; }

        [Required]
        public int? Heath { get; set; }

        [Required]
        public int? Damage { get; set; }

        public List<Items>? Items { get; set; }
    }
}
