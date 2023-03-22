namespace ProductManagement.Models.Products
{
    public class ProductRepository : iProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext productContext) { 
            _context = productContext;
        }

        public Product GetProduct(int ID)
        {
            return _context.Products.Find(ID);
        }


        public IEnumerable<Product> GetAll()
        {
            _context.SaveChanges();
            return _context.Products;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }
    }
}
