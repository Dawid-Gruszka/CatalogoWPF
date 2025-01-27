namespace CatálogoDeProductos.Models
{
    internal class Categories
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product> Products { get; set; } = [];
        
        public Categories(string name) {
            this.Name = name;
        }
    }
}
