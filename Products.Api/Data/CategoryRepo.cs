using Products.Api.Models;

namespace Products.Api.Data
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApiDbContext _context;

        public CategoryRepo(ApiDbContext context)
        {
            _context = context;
        }
        public Category AddCategory(Category category)
        {
            if (category!=null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category;
            }
            return null;
        }

        public Category DeleteCategory(int id)
        {
            var result = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (result!=null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category UpdateCategory(int id, Category category)
        {
            var result = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (result!=null)
            {
                result.Name = category.Name;
                _context.Categories.Update(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
