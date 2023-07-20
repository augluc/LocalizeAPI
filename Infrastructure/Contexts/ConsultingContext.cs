using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ConsultingContext : DbContext
{
    public ConsultingContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite("Data Source=Localize.db");
    }

    public DbSet<ResultDb> Result { get; set; }
}
