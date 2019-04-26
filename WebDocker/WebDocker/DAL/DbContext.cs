using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDocker.DAL
{
    public class MySqlDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = 1, Name = "Ivan", Nickname = "IVy" },
            //    new User { Id = 2, Name = "Anton", Nickname = "Tony" });

        }
    }
}
