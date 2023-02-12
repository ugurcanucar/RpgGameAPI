using RpgGameAPI.Models;

namespace RpgGameAPI.Dtos.Character
{
    public class AddCharacterRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public int Strength { get; set; } = 10;
        public int HitPoint { get; set; } = 100;
        public int Defence { get; set; } = 10;
        public int İntelligence { get; set; } = 10;

        public int ClassId { get; set; } 

        //public RpgClass Class { get; set; } = RpgClass.Warrior;
    }
}
