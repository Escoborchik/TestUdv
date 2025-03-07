using TestUdv.Core.Models;

namespace TestUdv.Core.Interfaces
{
    public interface ICountingOccurrence
    {
        string CountOccurence(PostModel[] posts);
    }
}