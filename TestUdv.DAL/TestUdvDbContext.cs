using Microsoft.EntityFrameworkCore;
using TestUdv.DAL.Entities;

namespace TestUdv.DAL
{
    public class TestUdvDbContext : DbContext
    {
        public TestUdvDbContext(DbContextOptions<TestUdvDbContext> options) : base(options)
        {           
            Database.EnsureCreated();
        }

        public DbSet<NoteEntity> Notes { get; set; }              
    }
}
