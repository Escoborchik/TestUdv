using TestUdv.Core.Models;

namespace TestUdv.Core.Interfaces
{
    public interface INoteService
    {
        Task<NoteModel> CreateNote(string ownerId, string accessToken);
        Task<List<NoteModel>> GetAllNotes();
    }
}