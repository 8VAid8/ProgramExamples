
using Microsoft.EntityFrameworkCore;

namespace GuitarsProjectCore
{
    public class GuitarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=mysql;Uid=root;Pwd=;CharSet=utf8");
        }

        public DbSet<Guitar> Guitars { get; set; }
    }
}
