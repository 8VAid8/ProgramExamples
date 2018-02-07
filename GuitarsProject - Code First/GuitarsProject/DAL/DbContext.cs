using System.Data.Entity;

namespace GuitarsProject
{
    public class GuitarContext : DbContext
    {
        public GuitarContext() :
           base("GuitarDB")
        { }

        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<GuitarString> GuitarStrings { get; set; }
        public DbSet<Neck> Necks { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
    }
}
