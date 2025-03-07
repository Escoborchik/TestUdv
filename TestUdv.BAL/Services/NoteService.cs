using TestUdv.Core.Interfaces;
using TestUdv.Core.Models;

namespace TestUdv.BAL.Services
{
    public class NoteService(INoteRepository noteRepository, IVKService vkService, ICountingOccurrence counter) : INoteService
    {
        private readonly INoteRepository _noteRepository = noteRepository;
        private readonly IVKService _vkService = vkService;
        private readonly ICountingOccurrence _counter = counter;

        public async Task<List<NoteModel>> GetAllNotes()
        {
            return await _noteRepository.Get();
        }

        public async Task<NoteModel> CreateNote(string ownerId, string accessToken)
        {
            var posts = await _vkService.GetPosts(ownerId, accessToken);

            var occurrence = _counter.CountOccurence(posts);

            var note = new NoteModel(Guid.NewGuid(), long.Parse(ownerId), occurrence);

            await _noteRepository.Create(note);

            return note;

        }        
    }
}
