
using backend.Models;
using Microsoft.EntityFrameworkCore;
namespace backend.Data;

public class UsersStoreContext(DbContextOptions<UsersStoreContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserModel>().HasIndex(u => u.Email).IsUnique();
    }
}
