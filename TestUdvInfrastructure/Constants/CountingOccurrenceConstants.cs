using System.Text.Encodings.Web;
using System.Text.Json;

namespace TestUdvInfrastructure.Constants
{
    internal static class CountingOccurrenceConstants
    {
        public static readonly HashSet<char> Letters = new("абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz");

        public static readonly JsonSerializerOptions JsonOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

    }
}
