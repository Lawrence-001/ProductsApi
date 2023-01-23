using Products.Api.Models;

namespace Products.Api.Data
{
    public interface ICategoryRepo
    {
        Category GetCategoryById(int id);
        IEnumerable<Category> GetCategories();
        Category AddCategory(Category category);
        Category UpdateCategory(int id, Category category);
        Category DeleteCategory(int id);
    }
}
