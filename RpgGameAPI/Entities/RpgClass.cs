using System.Text.Json.Serialization;

namespace RpgGameAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Warrior=1,
        Mage=2,
        Archer=3,
        Assassin=4,
        Priest=5
    }
}
