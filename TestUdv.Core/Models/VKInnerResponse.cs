using System.Text.Json.Serialization;

namespace TestUdv.Core.Models
{
    public class VKInnerResponse
    {
        [JsonPropertyName("items")]
        public PostModel[] Items { get; set; }
    }
}
