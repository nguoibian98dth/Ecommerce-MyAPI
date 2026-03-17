using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Insfrastructure.DbContexts;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<PriceHistory> PriceHistory { get; set; }

    //public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<ProductVariant> ProductVariants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
