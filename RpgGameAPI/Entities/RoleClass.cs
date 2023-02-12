namespace RpgGameAPI.Models
{
    public class RoleClass
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int MaxLevel { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
