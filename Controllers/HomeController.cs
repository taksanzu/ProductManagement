using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Models.Products;
using ProductManagement.Models.ViewModels;
using System.Diagnostics;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        private iProductRepository productsRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(iProductRepository productsRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.productsRepository = productsRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "Home Page";
            return View(productsRepository.GetAll());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (model.Photopath != null)
                {
                    IFormFile image = model.Photopath;
                    ProcessImage(image, ref fileName);
                }
                Product product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Category = model.Category,
                    Price = model.Price,
                    Photopath = fileName
                };
                productsRepository.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int ID)
        {
            return View("UpdateProduct", productsRepository.GetProduct(ID));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            productsRepository.Update(product);
            return View("Index", productsRepository.GetAll());
        }

        public IActionResult DeleteProduct(int ID)
        {
            productsRepository.Delete(productsRepository.GetProduct(ID));
            return View("Index", productsRepository.GetAll());
        }
        /*
     * Hàm xử lý hình ảnh
     * 
     */
        private void ProcessImage(IFormFile image, ref string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            fileName = image.FileName;
            string filePath = Path.Combine(path, fileName);
            image.CopyTo(new FileStream(filePath, FileMode.Create));
        }
    }
}