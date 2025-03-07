using System.Text.Json.Serialization;

namespace TestUdv.Core.Models
{
    public class PostModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;    
    }
}
