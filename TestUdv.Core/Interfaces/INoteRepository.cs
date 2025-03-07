using TestUdv.Core.Models;

namespace TestUdv.Core.Interfaces
{
    public interface INoteRepository
    {
        Task Create(NoteModel note);
        Task<List<NoteModel>> Get();
    }
}