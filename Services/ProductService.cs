using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;
namespace CatálogoDeProductos.Services;


internal class ProductService(IRepositories<Product> repositorie) : IRepositoryService<Product>
{

    public void Add(Product item) => repositorie.Add(item);

    public void Delete(Product item) => repositorie.Delete(item);

    public Product Get(int id) => repositorie.Get(id);

    public List<Product> GetAll() => repositorie.GetAll();

    public void Update(Product item) => repositorie.Update(item);
}
