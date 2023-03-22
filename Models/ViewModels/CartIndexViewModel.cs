using ProductManagement.Models.Carts;

namespace ProductManagement.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
