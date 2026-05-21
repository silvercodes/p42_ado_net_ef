using _01_code_first;
using Microsoft.EntityFrameworkCore;

namespace _01_crud;

internal class Db : DbContext
{
    public Db()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=p42_crud_db;Trusted_Connection=True;Encrypt=False;");
}