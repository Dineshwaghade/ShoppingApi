using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext dbContext;

        public CategoryRepository(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            dbContext.SaveChanges();

            return category;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var category = await dbContext.Categories.ToListAsync();
            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var category = await dbContext.Categories.Where(x => x.Name == name).FirstOrDefaultAsync();
            return category;
        }

        public async Task UpdateCategory(Category category)
        {
            var categoryObj = await dbContext.Categories.FindAsync(category.Id);
            categoryObj.Name=category.Name;
            categoryObj.Description=category.Description;

            dbContext.Categories.Update(categoryObj);
            dbContext.SaveChanges();

        }
    }
}
