using ProductManagement.Models.Products;

namespace ProductManagement.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string CurrentCategory { get; set; }
    }
}
