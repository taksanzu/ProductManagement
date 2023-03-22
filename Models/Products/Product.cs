namespace ProductManagement.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Category{ get; set; }

        public string Photopath { get; set; }
    }
}
