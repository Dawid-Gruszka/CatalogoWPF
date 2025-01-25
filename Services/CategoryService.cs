using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;
namespace CatálogoDeProductos.Services
{
    internal class CategoryService(IRepositories<Categories> repositorie) : IRepositoryService<Categories>
    {
        public void Add(Categories item) => repositorie.Add(item);

        public void Delete(Categories item) => repositorie.Delete(item);

        public Categories Get(int id) => repositorie.Get(id);

        public List<Categories> GetAll() => repositorie.GetAll();

        public void Update(Categories item) => repositorie.Update(item);
    }
}
