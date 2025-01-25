using CatálogoDeProductos.Data;
using CatálogoDeProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatálogoDeProductos.Repositories
{
    internal class CategoryRepository(AppDbContext context) : IRepositories<Categories>
    {
        private readonly AppDbContext _context = context;
        public void Add(Categories item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Categories item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public Categories Get(int id) => _context.Category.ToList<Categories>().Find(c => c.Id == id);

        public List<Categories> GetAll() => _context.Category.ToList();

        public void Update(Categories item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
