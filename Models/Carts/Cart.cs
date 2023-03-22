using ProductManagement.Models.Products;

namespace ProductManagement.Models.Carts
{
    public class Cart
    {
        private List<CartItem> ItemCollection = new List<CartItem>();
        public virtual IEnumerable<CartItem> Items => ItemCollection;

        public virtual void AddItem(Product product, int quanity)
        {
            CartItem Item = ItemCollection.FirstOrDefault(p => p.product.Id == product.Id)!;
            if (Item == null)
            {
                ItemCollection.Add(new CartItem
                {
                    product = product,
                    Quantity = quanity
                });
            }
            else
            {
                Item.Quantity += quanity;
            }
        }

        public virtual void RemoveItem(Product product) =>
            ItemCollection.RemoveAll(l => l.product.Id == product.Id);

        public virtual double ComputeTotalValue() => ItemCollection.Sum(l => l.product.Price * l.Quantity);

        // write ComputeTotalValue function return decimal and using TryParse() to convert string to decimal

        public virtual void Clear() => ItemCollection.Clear();
    }
    public class CartItem
    {
        public int CartItemId { get; set; }

        public Product? product { get; set; }

        public int Quantity { get; set; }
    }
}
