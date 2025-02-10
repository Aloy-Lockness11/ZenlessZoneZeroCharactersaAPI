namespace ZenlessZoneZeroCharacterAPI.Models
{
    public class CharacterDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public List<ItemDTO>? Items { get; set; }
    }
}
