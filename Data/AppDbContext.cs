using CatálogoDeProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatálogoDeProductos.Data
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Categories> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId);
        });
    }
}
