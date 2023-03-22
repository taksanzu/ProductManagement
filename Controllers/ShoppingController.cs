using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models.Products;
using ProductManagement.Models.ViewModels;

namespace ProductManagement.Controllers
{
    public class ShoppingController : Controller
    {
        iProductRepository productsRepository;

        public ShoppingController(iProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            return View("List");
        }
        public IActionResult List(string category)
        {
            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                Products = productsRepository.GetAll().Where(p => category == null || p.Category == category).ToList(),
                CurrentCategory = category
            };
            return View("List", productListViewModel);
        }
    }
}
