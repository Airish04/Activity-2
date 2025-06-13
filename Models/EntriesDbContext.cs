using Microsoft.EntityFrameworkCore;

namespace Activity_2.Models
{
    public class EntriesDbContext : DbContext 
    {
        public DbSet<Library> Entries { get; set; }

        public EntriesDbContext(DbContextOptions<EntriesDbContext> options)
            : base(options)
        {

        }
    }
}
