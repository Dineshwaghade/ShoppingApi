using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext apiDbContext;

        public ProductRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await apiDbContext.Products.AddAsync(product);
            apiDbContext.SaveChanges();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await apiDbContext.Products.FindAsync(id);
            apiDbContext.Products.Remove(product);
            apiDbContext.SaveChanges();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await apiDbContext.Products.Include(x => x.Images).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await apiDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            var model = await apiDbContext.Products.FindAsync(product.Id);
            model.CategoryId = product.CategoryId;
            model.Code = product.Code;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            apiDbContext.Products.Update(model);
            apiDbContext.SaveChanges();

        }
    }
}
