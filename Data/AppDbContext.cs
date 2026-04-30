using Microsoft.EntityFrameworkCore;
using NotesAPI.Entities;

namespace NotesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base (options)
            { }
        public DbSet<Note> Notes => Set<Note>();
    }
}
