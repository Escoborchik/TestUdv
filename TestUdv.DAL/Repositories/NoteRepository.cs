using Microsoft.EntityFrameworkCore;
using TestUdv.Core.Interfaces;
using TestUdv.Core.Models;
using TestUdv.DAL.Entities;

namespace TestUdv.DAL.Repositories
{
    public class NoteRepository(TestUdvDbContext context) : INoteRepository
    {
        private readonly TestUdvDbContext _context = context;

        public async Task<List<NoteModel>> Get()
        {
            var notesEntities = await _context.Notes
                .AsNoTracking()
                .ToListAsync();

            var notes = notesEntities
                .Select(n => new NoteModel(n.Id, n.OwnerId, n.Occurrence))
                .ToList();

            return notes;
        }
        public async Task Create(NoteModel note)
        {
            var noteEntity = new NoteEntity
            {
                Id = note.Id,
                OwnerId = note.OwnerId,
                Occurrence = note.Occurrence
            };

            await _context.Notes.AddAsync(noteEntity);
            await _context.SaveChangesAsync();
            
        }        
    }
}
