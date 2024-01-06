using ShoppingAPI.Models;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await categoryRepository.CreateCategory(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await categoryRepository.DeleteCategory(id);
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return categoryRepository.GetAllCategories();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public Task<Category> GetCategoryByNameAsync(string name)
        {
            return categoryRepository.GetCategoryByName(name);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await categoryRepository.UpdateCategory(category);
        }
    }
}
