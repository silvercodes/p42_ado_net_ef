using Microsoft.EntityFrameworkCore;

namespace _01_code_first;

internal class Db: DbContext
{
    public Db()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=p42_ef_code_first_db;Trusted_Connection=True;Encrypt=False;");



}
