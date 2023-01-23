using Products.Api.Models;

namespace Products.Api.Data
{
    public interface IProductRepo
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
        Product AddProduct(Product product);
        Product UpdateProduct(int id, Product product);
        Product DeleteProduct(int id);
    }
}
