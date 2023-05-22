using Microsoft.EntityFrameworkCore;

namespace SharpReact.Model
{
    public class CitizenContext:DbContext
    {
        public CitizenContext(DbContextOptions<CitizenContext> options) : base(options)
        {

        }

        public DbSet<Citizen> Citizens { get; set; }
    }

}
