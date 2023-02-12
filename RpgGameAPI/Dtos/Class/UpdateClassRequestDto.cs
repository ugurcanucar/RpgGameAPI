namespace RpgGameAPI.Dtos.Class
{
    public class UpdateClassRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MaxLevel { get; set; }

    }
}
