namespace RpgGameAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Strength { get; set; } = 10;
        public int HitPoint { get; set; } = 100;
        public int Defence { get; set; } = 10;
        public int İntelligence { get; set; } = 10;
        public int ClassId { get; set; }

        public RoleClass Class { get; set; }

        //public RpgClass Class { get; set; } = RpgClass.Warrior;

    }
}
