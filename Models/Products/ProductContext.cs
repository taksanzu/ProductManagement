using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductManagement.Models.Carts;
using System;

namespace ProductManagement.Models.Products
{
    public class ProductContext : IdentityDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model
            modelBuilder.Ignore<CartItem>();
            // Make add Migration work
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.UserId });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.Value });
        }
        public DbSet<Product> Products { get; set; }
    }

    public class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            ConfigurationManager config = new ConfigurationManager();
            var connectionString = config.GetConnectionString("Localbb");
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ProductDB;" +
                "Trusted_Connection=True;MultipleActiveResultSets=true"
                );
            return new ProductContext(optionsBuilder.Options);
        }
    }
}
