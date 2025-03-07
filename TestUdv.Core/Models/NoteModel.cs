namespace TestUdv.Core.Models
{
    public class NoteModel(Guid id, long ownerId, string occurrence)
    {
        public Guid Id { get; set; } = id;
        public long OwnerId { get; set; } = ownerId;
        public string Occurrence { get; set; } = occurrence;
    }
}
