using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite("Data Source=Localize.db");
        }

        public DbSet<UserDb> Users { get; set; }
    }
}