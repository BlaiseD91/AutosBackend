using Microsoft.EntityFrameworkCore;

namespace AutosBackend.Models
{
    public class Jarmuvek: DbContext
    {
        public Jarmuvek(DbContextOptions<Jarmuvek> o) : base(o)
        {

        }

        public DbSet<Jarmu> jarmuvek { get; set; }
    }
}
