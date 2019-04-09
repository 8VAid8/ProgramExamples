using System.Data.Entity;

namespace GuitarsProject
{
    public class GuitarContext : DbContext
    {
        public GuitarContext() :
           base("GuitarDB")
        { }

        public DbSet<Guitar> Guitars { get; set; }
    }
}
