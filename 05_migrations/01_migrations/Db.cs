using Microsoft.EntityFrameworkCore;

namespace _01_migrations;

internal class Db: DbContext
{
    public DbSet<User> Users { get; set; }

    public Db()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=p42_ef_mig_db;Trusted_Connection=True;Encrypt=False;");
}
