namespace TestUdv.DAL.Entities
{
    public class NoteEntity
    {
        public Guid Id { get; set; }
        public long OwnerId { get; set; }
        public string Occurrence { get; set; } = string.Empty;

    }
}
