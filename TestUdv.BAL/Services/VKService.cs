using System.Text.Encodings.Web;
using System.Text.Json;
using TestUdv.Core.Interfaces;
using TestUdv.Core.Models;

namespace TestUdv.BAL.Services
{
    public class VKService(HttpClient httpClient) : IVKService
    {
        private readonly HttpClient _httpClient = httpClient;

        private string BuildVkApiUrl(string ownerId, string accessToken)
        {
            return $"https://api.vk.com/method/wall.get?owner_id={ownerId}&count=5&lang=ru&access_token={accessToken}&v=5.199";
        }

        public async Task<PostModel[]> GetPosts(string ownerId, string accessToken)
        {
            var url = BuildVkApiUrl(ownerId, accessToken);

            var response = await _httpClient.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            var posts = JsonSerializer.Deserialize<VKResponse>(result);

            return posts.Response.Items;
        }
    }
}
