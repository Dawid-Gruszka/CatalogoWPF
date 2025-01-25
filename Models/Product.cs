namespace CatálogoDeProductos.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }
        public Product() { }

        public Product(int id, string? name, string? description, Categories? category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }
    }
}
