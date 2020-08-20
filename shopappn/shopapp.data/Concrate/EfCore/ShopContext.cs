using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrate.EfCore
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder  dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=shopDb");
        }

        //fluent api ile conction yani productcategory tablosunun birincil anahtarını bildireceğim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
            .HasKey(c=>new {c.CategoryId,c.ProductId});
        }

        
    }
}