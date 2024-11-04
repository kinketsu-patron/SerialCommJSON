using System.Text.Json.Serialization;

namespace SerialCommJSON.Models
{
    public class Human
    {
        [JsonPropertyName( "name" )]
        public string Name { get; set; }

        [JsonPropertyName( "age" )]
        public uint Age { get; set; }

        [JsonPropertyName( "favorite_food" )]
        public string[ ] FavoriteFood { get; set; }

        [JsonPropertyName( "wife" )]
        public Wife Wife { get; set; }
    }

    public class Wife
    {
        [JsonPropertyName( "name" )]
        public string Name { get; set; }

        [JsonPropertyName( "age" )]
        public uint Age { get; set; }

        [JsonPropertyName( "favorite_food" )]
        public string[ ] FavoriteFood { get; set; }
    }
}
