using TestUdv.Core.Models;

namespace TestUdv.Core.Interfaces
{
    public interface IVKService
    {
        Task<PostModel[]> GetPosts(string Id, string accessToken);
    }
}