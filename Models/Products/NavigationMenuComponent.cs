using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Models.Products
{
    public class NavigationMenuComponent : ViewComponent
    {
        private iProductRepository productRepository;

        public NavigationMenuComponent(iProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/NavigationMenu/Default.cshtml", productRepository.GetAll()
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
