

using Microsoft.EntityFrameworkCore;

namespace GuitarsProject
{
    public class GuitarContext : DbContext
    {
        public GuitarContext(DbContextOptions<GuitarContext> options)
            : base(options)
        {
        }

        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<GuitarString> GuitarStrings { get; set; }
        public DbSet<Neck> Necks { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
    }
}
