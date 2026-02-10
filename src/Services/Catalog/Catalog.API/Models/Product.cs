namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; } = default!;
    }
}
