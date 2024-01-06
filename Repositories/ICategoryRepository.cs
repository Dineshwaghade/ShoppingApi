using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<List<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
