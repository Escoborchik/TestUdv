using Microsoft.Extensions.Logging;
using System.Text.Json;
using TestUdv.Core.Interfaces;
using TestUdv.Core.Models;
using static TestUdvInfrastructure.Constants.CountingOccurrenceConstants;

namespace TestUdvInfrastructure
{
    public class CountingOccurrence(ILogger<CountingOccurrence> logger) : ICountingOccurrence
    {       
        private readonly ILogger<CountingOccurrence> _logger = logger;
        private Dictionary<char, int> CountLetterFrequency(string text)
        {

            Dictionary<char, int> frequency = [];

            foreach (char c in text.ToLower())
            {
                if (Letters.Contains(c))
                {
                    if (frequency.TryGetValue(c, out int value))
                    {
                        frequency[c] = ++value;
                    }

                    else
                    {
                        frequency[c] = 1;
                    }                        
                }
            }

            return frequency.OrderBy(kv => kv.Key).ToDictionary(k => k.Key, v => v.Value);
        }

        public string CountOccurence(PostModel[] posts)
        {
            var frequency = new Dictionary<char, int>[posts.Length];
            
            _logger.LogInformation("Started occurrence counting");

            for (int i = 0; i < posts.Length; i++)
            {
                frequency[i] = CountLetterFrequency(posts[i].Text);
            }
          
            _logger.LogInformation("Ended occurrence counting");

            var result = JsonSerializer.Serialize(frequency, JsonOptions);

            return result;
        }
    }
}
