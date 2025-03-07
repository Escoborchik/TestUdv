using System.Text.Json.Serialization;

namespace TestUdv.Core.Models
{
    public class VKResponse
    {
        [JsonPropertyName("response")]
        public VKInnerResponse Response { get; set; }
    }
}
