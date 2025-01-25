using CatálogoDeProductos.Data;
using CatálogoDeProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatálogoDeProductos.Repositories
{
    internal class ProductRepositories(AppDbContext context) : IRepositories<Product>
    {
        private readonly AppDbContext _context = context;
        public void Add(Product item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Product item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public Product Get(int id) => _context.Products.ToList<Product>().Find(c => c.Id == id);

        public List<Product> GetAll() => _context.Products.ToList();

        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
