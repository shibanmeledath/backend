using System;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class ProductStoreContext (DbContextOptions<ProductStoreContext> options):DbContext(options)
{
public DbSet<ProductModel> Product { get; set; }
 protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductModel>();
    }
}
