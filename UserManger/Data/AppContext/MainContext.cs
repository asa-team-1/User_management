using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.AppContext
{
    public class MainContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = User_db; Trusted_Connection = True;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }


    }
}
