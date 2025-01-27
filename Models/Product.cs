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

        public Product(string name, string description, Categories category)
        {
            this.Name = name;
            this.Description = description;
            this.Category = category;
        }

        public Product(string name,string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public Product(int id,string name,string description,Categories category)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Category = category;
        }
    }
}
