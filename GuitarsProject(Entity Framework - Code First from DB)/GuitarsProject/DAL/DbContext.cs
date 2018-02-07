using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
