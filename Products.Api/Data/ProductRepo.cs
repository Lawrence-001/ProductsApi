using Products.Api.DTOs.Product;
using Products.Api.Models;

namespace Products.Api.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApiDbContext _context;

        public ProductRepo(ApiDbContext context)
        {
            _context = context;
        }
        public Product AddProduct(Product product)
        {
            //var _product = new Product()
            //{
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    PictureName = product.PictureName,
            //    CompanyId = product.CompanyId,
            //    CategoryId = product.CategoryId,
            //};
            //_context.Products.Add(_product);
            //_context.SaveChanges();
            //return _product;
            if (product != null)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            return null;
        }

        public Product DeleteProduct(int id)
        {
            var result = _context.Products.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Products.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        //public ProductWithCategories GetProductWithDetails(int id)
        //{
        //    var _produWithDetails = _context.Products.Where(p => p.Id == id).Select(prod => new ProductWithCategories()
        //    {
        //        Name = prod.Name,
        //        Description = prod.Description,
        //        Price = prod.Price,
        //        PictureName = prod.PictureName,
        //        CompanyName = prod.Company.Name,
        //        CategoryName = prod.Company.Name
        //    }).FirstOrDefault();
        //    return (ProductWithCategories)_produWithDetails;
        //}

        public Product UpdateProduct(int id, Product product)
        {
            var result = _context.Products.FirstOrDefault(p => p.Id == id);
            if (result!=null)
            {
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = product.Price;
                result.PictureName = product.PictureName;

                _context.Products.Update(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
