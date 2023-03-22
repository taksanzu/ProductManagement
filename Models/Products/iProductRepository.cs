namespace ProductManagement.Models.Products
{
    public interface iProductRepository
    {
        Product GetProduct(int id);

        IEnumerable<Product> GetAll();

        Product Add(Product product);

        Product Update(Product product);

        Product Delete(Product product);
    }
}
