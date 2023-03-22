namespace ProductManagement.Models.ViewModels
{
    public class CreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }

        public IFormFile Photopath { get; set; }
    }
}
